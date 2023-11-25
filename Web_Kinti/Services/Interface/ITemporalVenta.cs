using Web_Kinti.Models;

namespace Web_Kinti.Services.Interface
{
    public interface ITemporalVenta
    {
        void add(TemporalVenta temporalVenta);
        IEnumerable<TemporalVenta> GetAllTemporySale();
    }
}
