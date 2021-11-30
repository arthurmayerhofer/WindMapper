using mvc.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mvc
{
    public interface IDataWindRoseService
    {
        List<List<float>> CreateDirectionData(Tuple<List<float>, List<float>> allData);
        List<List<float>> CreateVelocityData(Tuple<List<float>, List<float>> allData);
        Tuple<List<float>, List<float>> DataToTuple(DataWindRoseViewModel data);
        Task<Tuple<List<List<float>>, List<List<float>>>> GetDataWindRose();
    }
}