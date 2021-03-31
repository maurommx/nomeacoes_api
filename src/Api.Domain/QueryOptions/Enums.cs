using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.QueryOptions
{
    public enum OperatorsEnum
    {
        IGUAL,
        DIFERENTE,
        MENOR,
        MENOROUIGUAL,
        MAIOR,
        MAIOROUIQUAL,
        COMECACOM,
        CONTEM,
        TERMINACOM
    }

    public enum OrderByEnum
    {
        ASC,
        DESC
    }
}
