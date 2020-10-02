using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    using System;
    using OxyPlot;
    using OxyPlot.Series;
    using Prism.Mvvm;
    using Prism.Commands;
    using System.Text;
    using System.Windows;

    class OxyPlotModel : BindableBase
    {
        private OxyPlot.PlotModel plotModel;
        private double t;
        private double x;
        private string[] dataval;
        private double thick;
        private OxyPlot.PlotModel interpolationPlotModel;
        private int slider;

        public OxyPlot.PlotModel PlotModel
        {
            get
            {
                return plotModel;
            }
            set
            {
                SetProperty(ref plotModel, value);
            }
        }
        public double Temperature
        {
            get
            {
                return t;
            }

            set
            {
                SetProperty(ref t, value);
            }
        }
        
        public double Coefficient_X
        {
            get
            {
                return x;
            }

            set
            {
                SetProperty(ref x, value);
            }
        }
        public string[] DataValues
        {
            get
            {
                return dataval;
            }
            set
            {
                SetProperty(ref dataval, value);
            }
        }
        public double Thickness
        {
            get
            {
                return thick;
            }
            set
            {
                SetProperty(ref thick, value);
            }
        }
        public OxyPlot.PlotModel InterpolationPlotModel
        {
            get
            {
                return interpolationPlotModel;
            }
            set
            {;
                SetProperty(ref interpolationPlotModel, value);
            }
        }
        public int SlValue
        {
            get
            {
                return slider;
            }
            set
            {
                SetProperty(ref slider, value);
            }
        }
 

        public DelegateCommand GenerateChartCommand { get; private set; }
        public DelegateCommand GenerateStartCommand { get; private set; }
        public DelegateCommand GenerateChartCommandNoStrains { get; private set; }
        public DelegateCommand GenerateSaveInterpolationCommand { get; private set; }
        public DelegateCommand GenerateSaveAllCommand { get; private set; }
        public DelegateCommand GenerateSaveAllNoStrainsCommand { get; private set; }
        public DelegateCommand GenerateStructureCommand { get; private set; }
        public DelegateCommand GenerateStructureNoStrainsCommand { get; private set; }





        public OxyPlotModel()
        {
            PlotModel = new PlotModel();
            InterpolationPlotModel = new PlotModel();
            GenerateChartCommand = new DelegateCommand(GenerateChart);
            GenerateStartCommand = new DelegateCommand(GenerateStart);
            GenerateChartCommandNoStrains = new DelegateCommand(GenerateChartNoStrains);
            GenerateSaveInterpolationCommand = new DelegateCommand(GenerateSaveInterpolation);
            GenerateSaveAllCommand = new DelegateCommand(GenerateSaveAll);
            GenerateSaveAllNoStrainsCommand = new DelegateCommand(GenerateSaveAllNoStrains);
            GenerateStructureCommand = new DelegateCommand(GenerateStructure);
            GenerateStructureNoStrainsCommand = new DelegateCommand(GenerateStructureNoStrains);



        }

        private void GenerateStructure()
        {
            var sc = new SemiConductor(x, t);
            //ec line series
            plotModel.Series.Clear();
            var last = new LineSeries { 
                Title="E_C",
                Color = OxyColors.Green
            };
            last.Points.Add(new DataPoint(30,sc.Energy_C()));
            last.Points.Add(new DataPoint((30 + Thickness),sc.Energy_C()));
            PlotModel.Series.Add(last);
            
                var lasb = new LineSeries {
                    Title = "E_HH",
                    Color = OxyColors.DarkGreen
                };

                lasb.Points.Add(new DataPoint(30, (sc.Energy_HH())));
                lasb.Points.Add(new DataPoint((30 + Thickness), (sc.Energy_HH())));
                PlotModel.Series.Add(lasb);
            
            
                var lasc = new LineSeries {
                    Title="E_LH",
                    Color = OxyColors.GreenYellow
                };

                lasb.Points.Add(new DataPoint(30, (sc.Energy_LH())));
                lasb.Points.Add(new DataPoint((30 + Thickness), (sc.Energy_LH())));
                PlotModel.Series.Add(lasc);
            
            var lt = new LineSeries {
                Color = OxyColors.Blue
            };
            lt.Points.Add(new DataPoint(0,sc.VBO_GaAs()));
            lt.Points.Add(new DataPoint(30,sc.VBO_GaAs()));
            PlotModel.Series.Add(lt);
            var rt = new LineSeries
            {
                Color = OxyColors.Blue
            };
            rt.Points.Add(new DataPoint((30 + Thickness), sc.VBO_GaAs()));
            rt.Points.Add(new DataPoint((60+Thickness), sc.VBO_GaAs()));
            PlotModel.Series.Add(rt);
            var lb = new LineSeries
            {
                Color = OxyColors.DarkViolet
            };
            lb.Points.Add(new DataPoint(0,(sc.Energy_Gap_GaAs() + sc.VBO_GaAs())));
            lb.Points.Add(new DataPoint(30,(sc.Energy_Gap_GaAs() + sc.VBO_GaAs())));
            PlotModel.Series.Add(lb);
            var rb = new LineSeries
            {
                Color = OxyColors.DarkViolet
            }; ;
            rb.Points.Add(new DataPoint((30 + Thickness),(sc.Energy_Gap_GaAs() + sc.VBO_GaAs())));
            rb.Points.Add(new DataPoint((60+Thickness),(sc.Energy_Gap_GaAs() + sc.VBO_GaAs())));
            PlotModel.Series.Add(rb);
            PlotModel.InvalidatePlot(true);
        }
        private void GenerateStructureNoStrains()
        {
            var sc = new SemiConductor(x, t);
            //ec line series
            plotModel.Series.Clear();
            var last = new LineSeries
            {
                Title = "E_C",
                Color = OxyColors.Orange
            }; ;
            last.Points.Add(new DataPoint(30, sc.VBO()+sc.Energy_Gap()));
            last.Points.Add(new DataPoint((30 + Thickness), sc.VBO()+sc.Energy_Gap()));
            PlotModel.Series.Add(last);
            var lasb = new LineSeries
            {
                Title="E_V",
                Color = OxyColors.OrangeRed
            };
            lasb.Points.Add(new DataPoint(30, (sc.VBO())));
            lasb.Points.Add(new DataPoint((30 + Thickness), (sc.VBO())));
            PlotModel.Series.Add(lasb);
            var lt = new LineSeries
            {
                Color = OxyColors.DarkBlue
            };
            lt.Points.Add(new DataPoint(0, sc.VBO_GaAs()));
            lt.Points.Add(new DataPoint(30, sc.VBO_GaAs()));
            PlotModel.Series.Add(lt);
            var rt = new LineSeries
            {
                Color = OxyColors.DarkBlue
            };
            rt.Points.Add(new DataPoint((30 + Thickness), sc.VBO_GaAs()));
            rt.Points.Add(new DataPoint((60 + Thickness), sc.VBO_GaAs()));
            PlotModel.Series.Add(rt);
            var lb = new LineSeries
            {
                Color = OxyColors.DarkGreen
            };
            lb.Points.Add(new DataPoint(0, (sc.Energy_Gap_GaAs() + sc.VBO_GaAs())));
            lb.Points.Add(new DataPoint(30, (sc.Energy_Gap_GaAs() + sc.VBO_GaAs())));
            PlotModel.Series.Add(lb);
            var rb = new LineSeries
            {
                Color = OxyColors.DarkGreen
            };
            rb.Points.Add(new DataPoint((30 + Thickness), (sc.Energy_Gap_GaAs() + sc.VBO_GaAs())));
            rb.Points.Add(new DataPoint((60 + Thickness), (sc.Energy_Gap_GaAs() + sc.VBO_GaAs())));
            PlotModel.Series.Add(rb);
            PlotModel.InvalidatePlot(true);
        }
        private void GenerateChart()
        {
            var sc = new SemiConductor(x, t);
            plotModel.Series.Clear();
            //ec line series
            double E_C, E_HH, E_LH, E_SH;
            E_C = sc.Energy_C();
            var ec = new LineSeries {
                MarkerType = MarkerType.Circle,
                StrokeThickness = 1,
                MarkerSize = 5,
                Title="E_C"
            };
            ec.Points.Add(new DataPoint(0, E_C));
            plotModel.Series.Add(ec);

            E_HH = sc.Energy_HH();
            var ehh = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                StrokeThickness = 1,
                MarkerSize = 5,
                Title="E_HH"
            };
            ehh.Points.Add(new DataPoint(0,E_HH));
            plotModel.Series.Add(ehh);

            E_LH = sc.Energy_LH();
            var elh = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                StrokeThickness = 1,
                MarkerSize = 5,
                Title="E_LH"
            };
            elh.Points.Add(new DataPoint(0, E_LH));
            plotModel.Series.Add(elh);

            E_SH = sc.Energy_SH();
            var esh = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                StrokeThickness = 1,
                MarkerSize = 5,
                Title="E_SH"
            };
            esh.Points.Add(new DataPoint(0, E_SH));
            plotModel.Series.Add(esh);

            PlotModel.InvalidatePlot(true);
        }
        private void GenerateChartNoStrains()
        {
            var sc = new SemiConductor(x, t);
            plotModel.Series.Clear();
            //ec line series
            double E_C, E_HH, E_LH, E_SH;
            E_C = sc.VBO()+sc.Energy_Gap();
            var ec = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                StrokeThickness = 1,
                MarkerSize = 5,
                Title = "E_C"
            };
            ec.Points.Add(new DataPoint(0, E_C));
            plotModel.Series.Add(ec);

            E_HH = sc.VBO();
            var ehh = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                StrokeThickness = 1,
                MarkerSize = 5,
                Title = "E_HH"
            };
            ehh.Points.Add(new DataPoint(0, E_HH));
            plotModel.Series.Add(ehh);

            E_LH = sc.VBO();
            var elh = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                StrokeThickness = 1,
                MarkerSize = 5,
                Title = "E_LH"
            };
            elh.Points.Add(new DataPoint(0, E_LH));
            plotModel.Series.Add(elh);

            E_SH = sc.VBO()-sc.DeltaSO();
            var esh = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                StrokeThickness = 1,
                MarkerSize = 5,
                Title = "E_SH"
            };
            esh.Points.Add(new DataPoint(0, E_SH));
            plotModel.Series.Add(esh);

            PlotModel.InvalidatePlot(true);
        }
        private void GenerateStart()
        {
            var sc = new SemiConductor(x, t);
            var path = @"C:\Users\Vosming\source\repos\Zad2\Values.txt";
            string[] data = new string[5];
            data[0] = "GaInAs";
            data[1] = $"Calculated Values for Temperature = {t}K, and X fraction of {x}";
            data[2] = $"Energy_C = {sc.Energy_C()}eV | Energy_HH = {sc.Energy_HH()}eV | Energy_LH = {sc.Energy_LH()}eV | Energy_SH = {sc.Energy_SH()}eV";
            data[3] = $"e mass = {sc.Mass_e()} | HH mass = {sc.Mass_HH()} | LH mass = {sc.Mass_LH()} | Delta SO = {sc.DeltaSO()}";
            data[4] = $"Energy Gap of GaAsIn {sc.Energy_Gap()}eV | GaAs {sc.Energy_Gap_GaAs()}eV | InAs {sc.Energy_Gap_InAs()}eV";

            System.IO.File.WriteAllLines(path, data);

            InterpolationPlotModel.Series.Clear();
            InterpolationPlotModel.Series.Add(new FunctionSeries(y => sc.Energy_Gap_Function(y, t), 0, 1, 0.005));
            InterpolationPlotModel.InvalidatePlot(true);

        }
        private void GenerateSaveInterpolation()
        {
            var sc = new SemiConductor(x, t);
            var path = @"C:\Users\Vosming\source\repos\Zad2\InterpolationValues.txt";
            string[] data = new string[102];
            data[0] = "X_Fraction;Energy_Gap";
            double counter = 0;
            int line = 1;
            while(counter<1.01)
            {
                data[line] = $"{counter};{sc.Energy_Gap_Function(counter,t)}";
                counter = counter + 0.01;
                line = line + 1;
            }

            System.IO.File.WriteAllLines(path, data);
        }
        private void GenerateSaveAll()
        {
            
            var path = @"C:\Users\Vosming\source\repos\Zad2\AllValues.txt";
            string[]data = new string[101];
            //data[0] = "Coefficient_X;Temperature;Energy_Gap;E_C;E_HH;E_LH;E_SH;mass_e;mass_HH;mass_LH";
            //data[1] = $"{x};{t};{sc.Energy_Gap()};{sc.Energy_C()};{sc.Energy_HH()};{sc.Energy_LH()};{sc.Energy_SH()};{sc.Mass_e()};{sc.Mass_HH()};{sc.Mass_LH()}";
            for (int i = 0; i < 101; i++)
            {
                var sc = new SemiConductor(i, t);
                data[i]= $"{x};{sc.Energy_Gap()};{sc.Energy_C()};{sc.Energy_HH()};{sc.Energy_LH()};{sc.Energy_SH()};{sc.Mass_e()};{sc.Mass_HH()};{sc.Mass_LH()}";
            }

            System.IO.File.WriteAllLines(path, data);

        }
        private void GenerateSaveAllNoStrains()
        {
            var sc = new SemiConductor(x, t);
            var path = @"C:\Users\Vosming\source\repos\Zad2\AllValuesNoStrains.txt";
            string[] data = new string[2];
            data[0] = "Coefficient_X;Temperature;Energy_Gap;E_C;E_HH;E_LH;E_SH;mass_e;mass_HH;mass_LH";
            data[1] = $"{x};{t};{sc.Energy_Gap()};{sc.VBO()+sc.Energy_Gap()};{sc.VBO()};{sc.VBO()};{sc.VBO()-sc.DeltaSO()};{sc.Mass_e()};{sc.Mass_HH()};{sc.Mass_LH()}";

            System.IO.File.WriteAllLines(path, data);

        }


    }
}
