using System.Collections;
using Web_Kinti.Models;
using Web_Kinti.Services.Interface;

namespace Web_Kinti.Services.Repository
{
    public class TemporalVentaRepository : ITemporalVenta
    {
        private List<TemporalVenta> _temporalVentaList = new List<TemporalVenta>();
        public void add(TemporalVenta temporalVenta)
        {
            _temporalVentaList.Add(temporalVenta);  
        }

        public IEnumerable<TemporalVenta> GetAllTemporySale()
        {
            return _temporalVentaList;
        }
    }
}
