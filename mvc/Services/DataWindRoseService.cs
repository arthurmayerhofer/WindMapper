using mvc.DTO;
using mvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc
{
    public partial class Startup
    {
        class DataWindRoseService : IDataWindRoseService
        {
            private readonly IDataWindRoseRepository dataWindRoseRepository;

            public DataWindRoseService(IDataWindRoseRepository dataWindRoseRepository)
            {
                this.dataWindRoseRepository = dataWindRoseRepository;
            }

            public async Task<Tuple<List<List<float>>, List<List<float>>>> GetDataWindRose()
            {
                var dataFormat = await dataWindRoseRepository.GetDataWindRose();

                List<List<float>> dataVelocityChart = CreateVelocityData(DataToTuple(dataFormat));
                List<List<float>> dataDirectionChart = CreateDirectionData(DataToTuple(dataFormat));

                Tuple<List<List<float>>, List<List<float>>> data = Tuple.Create(dataVelocityChart, dataDirectionChart);

                return data;
            }



            public Tuple<List<float>, List<float>> DataToTuple(DataWindRoseViewModel data)
            {
                List<float> listVelocidade = data.Velocidade;
                List<float> listDirecao = data.Direcao;

                Tuple<List<float>, List<float>> dataFormat = Tuple.Create(listVelocidade, listDirecao);

                return dataFormat;
            }

            public List<List<float>> CreateVelocityData(Tuple<List<float>, List<float>> allData)
            {
                List<float> allDir = allData.Item2;
                List<float> allVel = allData.Item1;

                List<float> counter = new List<float>();

                float initVel = 0; float rangeVel = 0.5f;
                float countVelRange = 1;
                float freq = 0;

                while (countVelRange <= 8)
                {
                    for (int i = 0; i < (allDir.Count); i++)
                    {
                        if (allDir[i] >= 355 || allDir[i] < 5)
                        {
                            if (countVelRange < 8)
                            {
                                if ((allVel[i] >= initVel) && (allVel[i] < (initVel + rangeVel))) freq += 1;
                            }
                            else if (countVelRange == 8) if (allVel[i] >= 4) freq += 1;
                        }
                    }
                    counter.Add(freq);
                    freq = 0;
                    initVel += rangeVel;
                    countVelRange += 1;
                }

                freq = 0;
                initVel = 0;
                countVelRange = 1;

                float initAngle = 5; float rangeAngle = 10;
                float countAngleRange = 1;

                while (countAngleRange <= 35)
                {
                    while (countVelRange <= 8)
                    {
                        for (int i = 0; i < (allDir.Count); i++)
                        {
                            if (allDir[i] >= initAngle && allDir[i] < (initAngle + rangeAngle))
                            {
                                if (countVelRange < 8)
                                {
                                    if ((allVel[i] >= initVel) && (allVel[i] < (initVel + rangeVel))) freq += 1;
                                }
                                else if (countVelRange == 8) if (allVel[i] >= 4) freq += 1;
                            }
                        }
                        counter.Add(freq);
                        freq = 0;
                        initVel += rangeVel;
                        countVelRange += 1;
                    }
                    initVel = 0;
                    countVelRange = 1;
                    initAngle += rangeAngle;
                    countAngleRange += 1;
                }

                List<float> percentCounter = new List<float>();
                float percentGeneral;

                foreach (float c in counter)
                {
                    if (c != 0)
                    {
                        percentGeneral = c * 100 / counter.Sum();
                        percentCounter.Add(percentGeneral);
                    }
                    else
                    {
                        percentGeneral = 0;
                        percentCounter.Add(percentGeneral);
                    }
                }

                List<List<float>> windRoseVelocity = new List<List<float>>();

                int countArray = 0; int pos;

                while (countArray <= 7)
                {
                    pos = countArray;
                    List<float> wrArray = new List<float>();

                    while (pos < 288)
                    {
                        wrArray.Add(percentCounter[pos]);
                        pos += 8;
                    }
                    windRoseVelocity.Add(wrArray);
                    countArray += 1;
                }

                return windRoseVelocity;
            }

            public List<List<float>> CreateDirectionData(Tuple<List<float>, List<float>> allData)
            {
                List<float> allDir = allData.Item2;
                List<float> counter = new List<float>();

                float freq = 0;

                foreach (float dir in allDir) if (dir >= 355 || dir < 5) freq += 1;
                counter.Add(freq);

                freq = 0;

                float initAngle = 5; float rangeAngle = 10;
                float countAngleRange = 1;

                while (countAngleRange <= 35)
                {
                    foreach (float dir in allDir) if ((dir >= initAngle) && (dir < (initAngle + rangeAngle))) freq += 1;
                    counter.Add(freq);
                    freq = 0;
                    initAngle += rangeAngle;
                    countAngleRange += 1;
                }

                List<float> percentCounter = new List<float>();
                float percentGeneral;

                foreach (float c in counter)
                {
                    if (c != 0)
                    {
                        percentGeneral = c * 100 / counter.Sum();
                        percentCounter.Add(percentGeneral);
                    }
                    else
                    {
                        percentGeneral = 0;
                        percentCounter.Add(percentGeneral);
                    }
                }

                List<List<float>> windRoseDirection = new List<List<float>>();

                float initFreq = 0; float freqRange = 1;
                int countDirArrays = 1;

                while (countDirArrays <= 8)
                {
                    List<float> wrArray = new List<float>();

                    for (int i = 0; i < (percentCounter.Count); i++)
                    {
                        if (countDirArrays < 8)
                        {
                            if ((percentCounter[i] >= initFreq) && (percentCounter[i] < (initFreq + freqRange))) wrArray.Add(percentCounter[i]);
                            else wrArray.Add(0);
                        }
                        else if (countDirArrays == 8)
                        {
                            if (percentCounter[i] >= 7) wrArray.Add(percentCounter[i]);
                            else wrArray.Add(0);
                        }
                    }
                    windRoseDirection.Add(wrArray);
                    initFreq += freqRange;
                    countDirArrays += 1;
                }

                return windRoseDirection;
            }

          
        }
    }
}
