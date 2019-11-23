using MarsRoverProject.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;

namespace MarsRoverProject.IoC
{
    public sealed class Mef
    {
        private static volatile Mef instance;
        CompositionContainer _container;

        #region Contructor
        private Mef()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "MarsRoverProject*.dll"));

            _container = new CompositionContainer(catalog);

            try
            {
                _container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }
        #endregion

        public static Mef Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Mef();
                }

                return instance;
            }
        }

        [Import]
        private ExportFactory<IPosition> positionFactory { get; set; }
        public IPosition GetPosition(int x, int y)
        {
            var p = positionFactory.CreateExport().Value;
            p.Init(x, y);

            return p;
        }

        [Import]
        private ExportFactory<IPlanet> planetFactory { get; set; }
        public IPlanet GetPlanet(int gridSize, IPosition startPosition = null, List<IPosition> obstables = null)
        {
            var p = planetFactory.CreateExport().Value;
            p.Init(gridSize, startPosition, obstables);

            return p;
        }

        [Import]
        private ExportFactory<IRover> roverFactory { get; set; }
        public IRover GetRover(IPlanet p, string directionFacing)
        {
            var r = roverFactory.CreateExport().Value;
            r.Init(p, directionFacing);

            return r;
        }

        [Import]
        private ExportFactory<IRoverCommandExecutor> roverCommandExecutorFactory { get; set; }
        public IRoverCommandExecutor GetRoverCommandExecutor()
        {
            return roverCommandExecutorFactory.CreateExport().Value;
        }

        [Import]
        private ExportFactory<IRoverController> roverControllerFactory { get; set; }
        public IRoverController GetRoverController(IPlanet p, string directionFacing)
        {
            var rc = roverControllerFactory.CreateExport().Value;
            rc.Init(p, directionFacing);

            return rc;
        }

        [Import]
        private ExportFactory<ICommandParser> commandParserFactory { get; set; }
        public ICommandParser GetCommandParser(IRover r)
        {
            var cp = commandParserFactory.CreateExport().Value;
            cp.Init(r);

            return cp;
        }

        [Import]
        private ExportFactory<ICmdResult> commandResultFactory { get; set; }
        public ICmdResult GetCmdResult()
        {
            return commandResultFactory.CreateExport().Value;
        }

        [ImportMany]
        private IEnumerable<ExportFactory<ICmd>> commandFactoryList { get; set; }
        public List<ICmd> GetCommands(IRover rover)
        {
            var list = new List<ICmd>();
            foreach (ExportFactory<ICmd> factory in commandFactoryList)
            {
                var c = factory.CreateExport().Value;
                c.Init(rover);

                list.Add(c);
            }

            return list;
        }
    }
}
