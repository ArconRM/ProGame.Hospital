using Microsoft.Extensions.DependencyInjection;
using Progame.HospitalAPI.BLL;
using ProGame.HospitalAPI.BLL.Interfaces;
using ProGame.HospitalAPI.DAL;
using ProGame.HospitalAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.Common.DependenciesInjection
{
    public class DependenciesResolver
    {
        public static IServiceProvider Kernel { get; set; }
        private static IServiceCollection _services { get; set; }

        static DependenciesResolver()
        {
            _services = new ServiceCollection();
            Kernel = Config();
        }

        private static IServiceProvider Config()
        {
            _services.AddTransient<IAppointmentService, AppointmentService>();
            _services.AddTransient<IDoctorService, DoctorService>();
            _services.AddTransient<IPatientService, PatientService>();
            _services.AddTransient<IRecordService, RecordService>();

            _services.AddTransient<IAppointmentDAO, AppointmentDAO>();
            _services.AddTransient<IDoctorDAO, DoctorDAO>();
            _services.AddTransient<IPatientDAO, PatientDAO>();
            _services.AddTransient<IRecordDAO, RecordDAO>();

            return _services.BuildServiceProvider();
        }
    }
}
