using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace MVCEFApp.Models
{
    public class RepositoryAppointment
    {
        public static List<Appointment> GetAppointments()
        {
            HospitalDbContext ctx = new HospitalDbContext();
            var list = ctx.Appointment.ToList();
            return list;
        }
        public static Appointment GetAppointmentById(int id)
        {
            HospitalDbContext ctx = new HospitalDbContext();
            var appointments = ctx.Appointment.Find(id);
            return appointments;
        }
        public static void AddNewAppointment(Appointment appointment)
        {
            HospitalDbContext ctx = new HospitalDbContext();
            ctx.Appointment.Add(appointment);
            ctx.SaveChanges();
        }

        public static void ModifyAppointment(Appointment appointment)
        {
            HospitalDbContext ctx = new HospitalDbContext();
            ctx.Entry(appointment).State = EntityState.Modified;
            ctx.SaveChanges();
        }
        public static void RemoveAppointment(int id)
        {
            HospitalDbContext ctx = new HospitalDbContext();
            Appointment appointment = ctx.Appointment.Find(id);
            ctx.Appointment.Remove(appointment);
            ctx.SaveChanges();
        }
    }
}

