using ProjetoContatos.App;
using ProjetoContatos.Dom.Models;
using System.Web.Mvc;

namespace ProjetoContatos.Controllers
{
    public class HomeController : Controller
    {
        private readonly PessoaAplication pessoaAplicacao = new PessoaAplication();

        public ActionResult Index()
        {
            var list = pessoaAplicacao.ListarAgenda();
            return View(list);
        }
        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken] // Gera um código no formulário, para que seja recebido aqui. Assim, quando outro pessoa de outro site não conseguir postar aqui nessa View.
        public ActionResult CadastrarContato()
        {
            var list = pessoaAplicacao.ListarAgenda();
            return View(list);

            //if (ModelState.IsValid)
            //{
            //    pessoaAplicacao.Salvar(pessoa);
            //    return RedirectToAction("Index");
            //}

            //return View(pessoa);
        }

        public ActionResult EditarContato(string id)
        {
            var list = pessoaAplicacao.ListarAgenda();
            return View(list);

            //var pessoa = pessoaAplicacao.ListarPorId(id);

            //if (pessoa == null)
            //{
            //    return HttpNotFound();
            //}

            //return View(pessoa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoaAplicacao.Salvar(pessoa);
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        public ActionResult Detalhes(string id)
        {
            var pessoa = pessoaAplicacao.ListarPorId(id);

            if (pessoa == null)
            {
                return HttpNotFound();
            }

            return View(pessoa);
        }

        public ActionResult Excluir(string id)
        {
            var pessoa = pessoaAplicacao.ListarPorId(id);

            if (pessoa == null)
            {
                return HttpNotFound();
            }

            return View(pessoa);
        }

        [HttpPost, ActionName("Excluir")] //Isso foi colocado para que a View acima (Excluir) possa vê esse Action (ExcluirConfirmado) como uma View de retorno.
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(string id)
        {
            var pessoa = pessoaAplicacao.ListarPorId(id);
            pessoaAplicacao.Excluir(pessoa);
            return RedirectToAction("Index");
        }
    }
}