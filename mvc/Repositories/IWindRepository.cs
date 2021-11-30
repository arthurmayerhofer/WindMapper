using mvc.Models;
using System.Collections.Generic;

namespace mvc.Repositories
{
    public interface IWindRepository
    {
        void SetWind();

        IList<Wind> GetWinds();

    }
}