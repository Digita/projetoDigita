using System.Collections.ObjectModel;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using projDigita.Models;
using Domain;
using System.Collections.Generic;
namespace projDigita.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

      
        public ActionResult Index(Player p)
        {
            return View(p);
        }



       
        [HttpPost]
        public ActionResult Logar(Player p)
        {
           
            //CÓDIGO CORRETO 
            
            var userDao = new UsuarioDAO();
            var user = userDao.obterUsuario(p.Nome, p.Senha);
            if (user == null)
            {
                ViewBag.Aviso = "Nome ou Senha incorreto!";
                return View("Index", p);
                
            }
            else
            {
                return View("Menu", PlayerMenu(user));
            }


            //            return View();

        }

        private PlayerMenu PlayerMenu(Usuario user)
        {

            usuarioGlobal = user;

            var pm = new PlayerMenu();
            pm.Pontos = (short)user.Acerto.Count;
            pm.IsFacil = true;
            pm.Fases = new List<Fase>();



            for (int i = 1; i < 7; i++)
            {
                var f = new Fase();
                f.Numero = i;
                f.solucao1 = false;
                f.solucao2 = false;
                f.solucao3 = false;
                f.solucao4 = false;
                f.solucao5 = false;

                foreach (var item in user.Acerto)
                {
                    if(item.Solucao.Id == 4){
                        f.solucao1 = true;
                        
                    }
                    if (item.Solucao.Id == 5)
                    {
                        f.solucao2 = true;
                    }
                    if (item.Solucao.Id == 6)
                    {
                        f.solucao3 = true;
                    }
                    if (item.Solucao.Id == 7)
                    {
                        f.solucao4 = true;
                    }
                    if (item.Solucao.Id == 8)
                    {
                        f.solucao5= true;
                    }

                }
                pm.Fases.Add(f);
                
            }

            return pm;
            
        }


        [HttpPost]
        public ActionResult Jogar(PlayerMenu pm)
        {
            if(pm.Escolida == 1)
                return View("Joga2", FaseNova());
            return View("Joga", FaseNova());

        }
        public ActionResult Joga2(Fase f)
        {
            return View(f);
        }

        public ActionResult Joga(Fase f)
        {
            return View(f);
        }

        private static Usuario usuarioGlobal;

        public ActionResult Acertou(Fase f)
        {
            var userDao = new UsuarioDAO();
            if(f.solucao1)
                usuarioGlobal.Acerto.Add(new Acerto{ Solucao = new Solucao{Id = 4}});
            if (f.solucao2)
                usuarioGlobal.Acerto.Add(new Acerto { Solucao = new Solucao { Id = 5 } });
            if (f.solucao3)
                usuarioGlobal.Acerto.Add(new Acerto { Solucao = new Solucao { Id = 6 } });
            if (f.solucao4)
                usuarioGlobal.Acerto.Add(new Acerto { Solucao = new Solucao { Id = 7 } });
            if (f.solucao5)
                usuarioGlobal.Acerto.Add(new Acerto { Solucao = new Solucao { Id = 8 } });



            userDao.atualizar(usuarioGlobal);

            return View("Menu", PlayerMenu(usuarioGlobal));
        }

        public ActionResult Menu(PlayerMenu p)
        {
            return View(p);
        }





        public ActionResult LoginUnico(string nome)
        {
            /*
             //CÓDIGO CORRETO
              
              UsuarioDAO userdDao = new UsuarioDAO();

            var listUsers = userdDao.obterUsuarios();
            return Json(listUsers.All(x => !x.Nome.Equals(nome)));
             */




            // CÓDIGO fAKE
            var listUsers = new Collection<string>()
           {
               "Caio",
               "Danton"
           };
            return Json(!listUsers.Contains(nome), JsonRequestBehavior.AllowGet);



        }

        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Player p)
        {
            if (ModelState.IsValid)
            {
             //CÓDIGO CORRETO
         
                var user = new Usuario();
                var userDao = new UsuarioDAO();

                user.Nome = p.Nome;
                user.Senha = p.Senha;
                user.Serie = p.Serie;
                user.Sexo = p.Sexo;
                user.Idade = p.Idade;
                


                userDao.salvar(user);




                return View("Menu", PlayerMenu(user));

            }
            else
            {
                ViewBag.Alerta = "dados incorretos!";
                return View();
            }


        }

        private PlayerMenu PlayerMenuFake()
        {


            var pm = new PlayerMenu();
            pm.Pontos = 1;
            pm.IsFacil = true;
            pm.Fases = new List<Fase>();
            pm.Fases.Add(new Fase { Numero = 1, solucao1 = true, solucao2 = false, solucao3 = true, solucao4 = false, solucao5 = false });
            pm.Fases.Add(new Fase { Numero = 2, solucao1 = true, solucao2 = false, solucao3 = true, solucao4 = false, solucao5 = false });
            pm.Fases.Add(new Fase { Numero = 3, solucao1 = true, solucao2 = false, solucao3 = true, solucao4 = false, solucao5 = false });
            pm.Fases.Add(new Fase { Numero = 4, solucao1 = true, solucao2 = false, solucao3 = true, solucao4 = false, solucao5 = false });
            pm.Fases.Add(new Fase { Numero = 5, solucao1 = true, solucao2 = false, solucao3 = true, solucao4 = false, solucao5 = false });
            pm.Fases.Add(new Fase { Numero = 6, solucao1 = true, solucao2 = false, solucao3 = true, solucao4 = false, solucao5 = false });

            return pm;
        }

        private Fase FaseNova()
        {
            var f = new Fase();
            f.Numero = 1;
            f.acertou = false;
            f.solucao1 = false;
            f.solucao2 = false;
            f.solucao3 = false;
            f.solucao4 = false;
            f.solucao5 = false;
            return f;
        }



    }
}
