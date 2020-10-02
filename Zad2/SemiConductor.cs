using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    public class SemiConductor
    {
        // Material constans for GaAs and InAs
        const double alc_GaAs = 5.65325;    //Angtrems
        const double alc_InAs = 6.0583;    //Angtrems
        const double alc_TCoeff_GaAs = 3.88 * 10e-5;    //Angstrems/K
        const double alc_TCoeff_InAs = 2.74 * 10e-5;    //Angstrems/k
        const double Eg0_GaAs = 1.519;  //eV
        const double Eg0_InAs = 0.417;  //eV
        const double alphaT_GaAs = 0.5405;  //meV/K
        const double alphaT_InAs = 0.276;   //meV/K
        const double betaT_GaAs = 204;  //K
        const double betaT_InAs = 93;   //K
        const double alphaC_GaAs = -9.3;    //eV
        const double alphaC_InAs = -5.08;    //eV
        const double alphaV_GaAs = -0.7;    //eV
        const double alphaV_InAs = 1.00;    //eV
        const double alphaC_CAB = 2.61;    //eV
        const double beta_GaAs = -2.0;  //eV
        const double beta_InAs = -1.8;  //eV
        const double c11_GaAs = 1221;   //GPa
        const double c12_GaAs = 566;    //GPa
        const double c11_InAs = 832.9;  //GPa
        const double c12_InAs = 452.6;   //GPa
        const double vbo_GaAs = -0.80;  //eV
        const double vbo_InAs = -0.59;  //eV
        const double vbo_GaInAs_bowing = -0.38; //eV
        const double deltaso_GaAs = 0.341;  //eV
        const double deltaso_InAs = 0.39;   //eV
        const double deltaso_GaInAs_bowing = 0.15;  //eV
        const double me_GaAs = 0.067;   //
        const double me_InAs = 0.024;   //
        const double me_GaInAs_bowing = 0.0091; //
        const double mhh_GaAs = 0.33;   //
        const double mhh_InAs = 0.26;   //
        const double mhh_GaInAs_bowing = -0.145;    //
        const double mlh_GaAs = 0.090;  //
        const double mlh_InAs = 0.027;  //
        const double mlh_GaInAs_bowing = 0.0202;    //
        //

        private double _x = 0;  //Fractuion of GaAs in GaInAs
        private double _T = 0;  // Temperature in Kelvins
        public SemiConductor(double X, double T)
        {
            _x = X;
            _T = T;
        }

        public double Energy_Gap()
        {
            double Pa, Pb, Cab;

            Pa = Eg0_GaAs - ((alphaT_GaAs * 10e-3 * (Math.Pow(_T, 2)) / (_T + betaT_GaAs)));
            Pb = Eg0_InAs - ((alphaT_InAs * 10e-3 * (Math.Pow(_T, 2)) / (_T + betaT_InAs)));
            Cab = 0.477;

            double Energy;

            Energy =( _x * Pa) + ((1 - _x) * Pb) -(_x * (1-_x) * Cab);

            return Energy;

        }
        public double Energy_Gap_Function(double cfx,double temp)
        {
            double Pa, Pb, Cab;

            Pa = Eg0_GaAs - ((alphaT_GaAs * 10e-3 * (Math.Pow(temp, 2)) / (temp + betaT_GaAs)));
            Pb = Eg0_InAs - ((alphaT_InAs * 10e-3 * (Math.Pow(temp, 2)) / (temp + betaT_InAs)));
            Cab = 0.477;

            double Energy;

            Energy = (cfx * Pa) + ((1 - cfx) * Pb) - (cfx * (1 - cfx) * Cab);

            return Energy;

        }

        public double Energy_Gap_GaAs()
        {
            double eg = Eg0_GaAs - ((alphaT_GaAs * 10e-3 * Math.Pow(_T, 2)) / (_T + betaT_GaAs));
            return eg;
        }
        public double Energy_Gap_InAs()
        {
            double eg = Eg0_InAs - ((alphaT_InAs * 10e-3 * Math.Pow(_T, 2)) / (_T + betaT_InAs));
            return eg;
        }

        public double Alpha_C()
        {
            double alphac = 0;
            alphac = _x * alphaC_GaAs + (1 - _x) * alphaC_InAs - _x * (1 - _x) * alphaC_CAB;
            return alphac;
        }

        public double Alpha_V()
        {
            double alphav = 0;
            alphav = _x * alphaV_GaAs + (1 - _x) * alphaV_InAs;
            return alphav;
        }

        public double Beta() //b deformation potencial interpolation
        {
            double beta = _x * beta_GaAs + (1 - _x) * beta_InAs;
            return beta;

        }

        public double A0() // Interpolation of a0
        {
            double a0, Pa, Pb;
            Pa = alc_GaAs + alc_TCoeff_GaAs * (300 - _T);
            Pb = alc_InAs + alc_TCoeff_InAs * (300 - _T);
            a0 = _x * Pa + (1 - _x) * Pb;
            return a0;

        }

        public double Parallel_Deformation() // ||
        {
            double e_para, ae, a0;
            a0 = A0();
            ae = alc_GaAs;
            e_para = (ae - a0 )/ ae;
            return e_para;

        }

        public double C11() // Interpolation of c11
        {
            double c11 = _x * c11_GaAs + (1 - _x) * c11_InAs;
            return c11;
            
        }

        public double C12() // Interpolation of c12
        {
            double c12 = _x * c12_GaAs + (1 - _x) * c12_InAs;
            return c12;
        }

        public double Perpendicural_Deformation ()
        {
            double e_perp, e_para,c11,c12;
            e_para = Parallel_Deformation();
            c11 = C11();
            c12 = C12();
            e_perp = -2*(c12/c11)*e_para;
            return e_perp;
        }

        public double VBO ()    // vallence band offset interpolation
        {
            double vbo = _x * vbo_GaAs + (1 - _x) * vbo_InAs - _x * (1 - _x) * vbo_GaInAs_bowing;
            return vbo;
        }

        public double VBO_GaAs()
        {
            return vbo_GaAs;
        }

        public double DeltaSO ()    //spin orbital energy interpolation
        {
            double deltaso = _x * deltaso_GaAs + (1 - _x) * deltaso_InAs - _x * (1 - _x) * deltaso_GaInAs_bowing;
            return deltaso;
        }
        
        public double Delta_Energy_ch ()    //delta Ech
        {
            double delta_Energy_ch = Alpha_C() * (Perpendicural_Deformation() + 2 * Parallel_Deformation());
            return delta_Energy_ch;
        }

        public double Delta_Energy_vh() //delta Evh
        {
            double delta_Energy_vh = Alpha_V() * (Perpendicural_Deformation() + 2 * Parallel_Deformation());
            return delta_Energy_vh;
        }

        public double Delta_Energy_vb() //delta Evb
        {
            double delta_Energy_vb = Beta() * (Perpendicural_Deformation() - Parallel_Deformation());
            return delta_Energy_vb;
        }

        public double Delta_Energy_vb_plus()    //delta E-vb
        {
            double delta_Energy_vb_plus = 0.5 * (Delta_Energy_vb() - DeltaSO() + Math.Sqrt(9 * Math.Pow(Delta_Energy_vb(), 2) + 2 * Delta_Energy_vb() * DeltaSO() + Math.Pow(DeltaSO(), 2)));
            return delta_Energy_vb_plus;
        }

        public double Delta_Energy_vb_minus()   // delta E+vb
        {
            double delta_Energy_vb_minus = 0.5 * (Delta_Energy_vb() - DeltaSO() - Math.Sqrt(9 * Math.Pow(Delta_Energy_vb(), 2) + 2 * Delta_Energy_vb() * DeltaSO() + Math.Pow(DeltaSO(), 2)));
            return delta_Energy_vb_minus;
        }

        // Energy calculation formules with deformations
        public double Energy_C()
        {
            double ec = VBO() + Energy_Gap() + Delta_Energy_ch();
            return ec;
        }

        public double Energy_HH()
        {
            double ehh = VBO() + Delta_Energy_vh() - Delta_Energy_vb();
            return ehh;
        }

        public double Energy_LH()
        {
            double elh = VBO() + Delta_Energy_vh() + Delta_Energy_vb_plus();
            return elh;
        }

        public double Energy_SH()
        {
            double esh = VBO() + Delta_Energy_vh() + Delta_Energy_vb_minus();
            return esh;
        }
        //

        //Mass Interpolation
        public double Mass_e()  // e mass interpolation
        {
            double me = _x * me_GaAs + (1 - _x) * me_InAs - _x * (1 - _x) * me_GaInAs_bowing;
            return me;
        }

        public double Mass_HH() //HH mass interpolation
        {
            double mhh = _x * mhh_GaAs + (1 - _x) * mhh_InAs - _x * (1 - _x) * mhh_GaInAs_bowing;
            return mhh;
        }

        public double Mass_LH() // LH mass interpolation
        {
            double mlh = _x * mlh_GaAs + (1 - _x) * mlh_InAs - _x*(1 - _x) * mlh_GaInAs_bowing;
            return mlh;
        }
        //

    }
}
