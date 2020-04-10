using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//include model,command and view
using JumbledWordSolver.Model;
using JumbledWordSolver.Comand;
using JumbledWordSolver.View;
using System.ComponentModel;

namespace JumbledWordSolver.ViewModel
{
    class JumbledWordSolverViewModel
    {
      public JumbledWordSolverViewModel()
        {
        }
      public JumbledWordSolverModel JumbledWordSolverModel1 { get; set; }
    }
}
