using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.DTO
{
    public class DataWindRoseViewModel
    {
        public List<float> Velocidade;
        public List<float> Direcao;

        public DataWindRoseViewModel()
        {
            Velocidade = new List<float>();
            Direcao = new List<float>();
        }
    }
}

/*
DataWindRoseViewModel
{
Velocidade:[FEWQERE, ASFWETFE, SDGERGTR,]
Direcao:[FEWQERE, ASFWETFE, SDGERGTR}
} 


GETJSON.DONE -> RESPOSTA  

    LISTA<> = RESPOSTA
*/