﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using multas_tB.Models;

namespace multas_tB.Controllers
{
    public class AgentesController : Controller
    {
    // cria uma variável que representa a Base de Dados
        private MultasBD db = new MultasBD();

        // GET: Agentes
        public ActionResult Index()
        {
            //db.Agentes.ToList() -> em SQL: SELECT * FROM Agentes;
            //enviar para a view uma lista com todos os agentes da Base de Dados;
            return View(db.Agentes.ToList());
        }

        // GET: Agentes/Details/5
        public ActionResult Details(int? id)
        // se se escrever int? é possivel não fornecer o valor de ID e não há erro!;

        //proteção para o caso de não ter sido fornecido um ID vãlido;      
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // procura na BD, o Agente cujo ID foi fornecido
            Agentes agentes = db.Agentes.Find(id);

            //proteção para o caso de não ter sido encontrado um Agente com ID fornecido;
            if (agentes == null)
            {
                return HttpNotFound();
            }
            // entrega à View os dados do Agente encontrado;
            return View(agentes);
        }

        // GET: Agentes/Create
        public ActionResult Create()
        {
            //apresenta a View para se inserir um novo Agente;
            return View();
        }

        // POST: Agentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //anotador para HTTP Post
        [HttpPost]
        //anotador para proteção por roubo de identidade
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Esquadra,Fotografia")] Agentes agentes)
        {
            //escrever os dados de um novo Agente na BD;

            // ModelState.IsValid -> Confronta od dados fornecidos da View com as exigências do Modelo
            if (ModelState.IsValid)
            {
                // adiciona o novo Agente à BD
                db.Agentes.Add(agentes);
                // faz 'Commit' às Alterações
                db.SaveChanges();
                // se tudo correr bem, redireciona para a página do Index;
                return RedirectToAction("Index");
            }
            // se houver erro, reapresenta os dados do Agente na View;
            return View(agentes);
        }

        // GET: Agentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agentes agentes = db.Agentes.Find(id);
            if (agentes == null)
            {
                return HttpNotFound();
            }
            return View(agentes);
        }

        // POST: Agentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Esquadra,Fotografia")] Agentes agentes)
        {
            if (ModelState.IsValid)
            {
                // neste caso já exite um Agente, apenas quero EDITAR os seus dados;
                db.Entry(agentes).State = EntityState.Modified;
                // efetuar 'Commit';
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agentes);
        }

        // GET: Agentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agentes agentes = db.Agentes.Find(id);
            if (agentes == null)
            {
                return HttpNotFound();
            }
            return View(agentes);
        }

        // POST: Agentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agentes agentes = db.Agentes.Find(id);
            // remove o Agente da BD;
            db.Agentes.Remove(agentes);
            // 'Commit';
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
