using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompuFrank.Data;
using CompuFrank.Models;
using Microsoft.AspNetCore.Authorization;

namespace CompuFrank.Views.compu_articulo
{
    public class compu_articuloController : Controller
    {
        private readonly ApplicationDbContext _context;

        public compu_articuloController(ApplicationDbContext context)
        {
            _context = context;
        }

                         /*************** METODO PARA FILTRO DE BÚSQUEDA *****************/
        /*
        public IList<compu_articulos> compu_articulos { get; set; }

        [BindProperty(SupportsGet = true)]
        public string valor_busqueda { get; set; }  //variable donde se guarda lo que introduce el usuario

        public SelectList categoria { get; set; }      //Variable donde tenemos la lista de los géneros

        [BindProperty(SupportsGet = true)]
        public string generoPelicula { get; set; }  //Variabale que guarda el género de la lista elegido por el usuario

        public async Task OnGetAsync()
        {
            var peliculas = from m in _context.compu_articulos
                            select m;
            if (!string.IsNullOrEmpty(valor_busqueda))  // Si lo que se ha buscado no es nulo o vacío
            {
                peliculas = peliculas.Where(s => s.producto.Contains(valor_busqueda));
            }

            IQueryable<string> generoQuery = from m in _context.compu_articulos
                                             orderby m.categoria
                                             select m.categoria;
            if (!string.IsNullOrEmpty(generoPelicula))
            {
                peliculas = peliculas.Where(s => s.categoria == generoPelicula);

            }

            //Movie = await _context.Movie.ToListAsync();
            categoria = new SelectList(await generoQuery.Distinct().ToListAsync());       // Filtrar por género
            compu_articulos = await peliculas.ToListAsync();     //Para mostrar solo la variable pelicula que contiene la búsqueda
        }
        */
                                    /******************************************************/


        // GET: compu_articulo
        public async Task<IActionResult> Index()
        {
            return View(await _context.compu_articulos.ToListAsync());
        }

        // GET: compu_articulo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compu_articulos = await _context.compu_articulos
                .FirstOrDefaultAsync(m => m.id == id);
            if (compu_articulos == null)
            {
                return NotFound();
            }

            return View(compu_articulos);
        }

        // GET: compu_articulo/Create

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: compu_articulo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,producto,categoria,precio,descripcion,url_imagen")] compu_articulos compu_articulos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compu_articulos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compu_articulos);
        }

        // GET: compu_articulo/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compu_articulos = await _context.compu_articulos.FindAsync(id);
            if (compu_articulos == null)
            {
                return NotFound();
            }
            return View(compu_articulos);
        }

        // POST: compu_articulo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,producto,categoria,precio,descripcion,url_imagen")] compu_articulos compu_articulos)
        {
            if (id != compu_articulos.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compu_articulos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!compu_articulosExists(compu_articulos.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(compu_articulos);
        }

        // GET: compu_articulo/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compu_articulos = await _context.compu_articulos
                .FirstOrDefaultAsync(m => m.id == id);
            if (compu_articulos == null)
            {
                return NotFound();
            }

            return View(compu_articulos);
        }

        // POST: compu_articulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compu_articulos = await _context.compu_articulos.FindAsync(id);
            _context.compu_articulos.Remove(compu_articulos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool compu_articulosExists(int id)
        {
            return _context.compu_articulos.Any(e => e.id == id);
        }
    }
}
