
using System;

namespace ABP
{
	/// <summary>
	/// Nodo da arvore binaria.
	/// </summary>
	class Nodo
	{
		public int Elemento; // Conteudo do nodo.

        public Nodo Pai; // Conteudo do nodo.

		public Nodo Esq; // Nodo da esquerda.
		public Nodo Dir; // Nodo da direita.

        public float Soma; // Media dos nós filhos

        public int Quantidade; // Media dos nós filhos
        public float Media; // Media dos nós filhos
		
		/// <summary>
		/// Construtor da classe.
		/// </summary>
		/// <param name="elemento">Conteudo do nodo.</param>
		/// <param name="esq">Nodo da esquerda.</param>
		/// <param name="dir">Nodo da direita.</param>
		public Nodo(int elemento, Nodo esq, Nodo dir, Nodo pai)
		{
			Elemento = elemento;
			Pai = pai;
			Esq = esq;
			Dir = dir;
		}
	}
	
	/// <summary>
	/// Arvore binaria de pesquisa.
	/// </summary>
	class Arvore
	{
		public Nodo Raiz; // Raiz da arvore.
		
		/// <summary>
		/// Construtor da classe.
		/// </summary>
		public Arvore()
		{
			Raiz = null;
		}
		
		/// <summary>
		/// Metodo publico iterativo para pesquisar elemento.
		/// </summary>
		/// <param name="elemento">Elemento que sera procurado.</param>
		/// <returns><code>true</code> se o elemento existir,
		/// <code>false</code> em caso contrario.</returns>
		public bool Pesquisar(int elemento)
		{
			return Pesquisar(Raiz, elemento);
		}
		
		/// <summary>
		/// Metodo privado recursivo para pesquisar elemento.
		/// </summary>
		/// <param name="nodo">Nodo em analise.</param>
		/// <param name="elemento">Elemento que sera procurado.</param>
		/// <returns><code>true</code> se o elemento existir,
		/// <code>false</code> em caso contrario.</returns>
		private bool Pesquisar(Nodo nodo, int elemento)
		{
			if (nodo == null) { return false; }
			else if (elemento < nodo.Elemento) { return Pesquisar(nodo.Esq, elemento); }
			else if (elemento > nodo.Elemento) { return Pesquisar(nodo.Dir, elemento); }
			else { return true; }
		}
		
		/// <summary>
		/// Metodo publico iterativo para exibir elementos.
		/// </summary>
		public void Mostrar()
		{
			Console.Write("[ ");
			Mostrar(Raiz);
			Console.WriteLine("]");
		}
		
		/// <summary>
		/// Metodo privado recursivo para exibir elementos.
		/// </summary>
		/// <param name="nodo">Nodo em analise.</param>
		private void Mostrar(Nodo nodo) 
		{
			if (nodo != null)
			{
				Mostrar(nodo.Esq); // Elementos da esquerda.
				Console.Write(nodo.Elemento + " "); // Conteudo do nodo.
				Mostrar(nodo.Dir); // Elementos da direita.
			}
		}
		
		/// <summary>
		/// Metodo publico iterativo para inserir elemento.
		/// </summary>
		/// <param name="elemento">Elemento a ser inserido.</param>
		public void Inserir(int elemento)
		{
			Raiz = Inserir(Raiz, elemento, null);
		}
		
		/// <summary>
		/// Metodo privado recursivo para inserir elemento.
		/// </summary>
		/// <param name="nodo">Nodo em analise.</param>
		/// <param name="elemento">Elemento a ser inserido.</param>
		/// <returns>Nodo em analise, alterado ou nao.</returns>
		private Nodo Inserir(Nodo nodo, int elemento, Nodo pai)
		{
			if (nodo == null) { nodo = new Nodo(elemento, null, null, pai); }
			else if (elemento < nodo.Elemento) { nodo.Esq = Inserir(nodo.Esq, elemento, nodo); }
			else if (elemento > nodo.Elemento) { nodo.Dir = Inserir(nodo.Dir, elemento, nodo); }
			else { Console.WriteLine("Erro ao inserir! O elemento ja esta presente na arvore!"); }
			
			return nodo;
		}
		
		/// <summary>
		/// Metodo publico iterativo para remover elemento.
		/// </summary>
		/// <param name="elemento">Elemento a ser removido.</param>
		public void Remover(int elemento)
		{
			Raiz = Remover(Raiz, elemento);
		}
		
		/// <summary>
		/// Metodo privado recursivo para remover elemento.
		/// </summary>
		/// <param name="nodo">Nodo em analise.</param>
		/// <param name="elemento">Elemento a ser removido.</param>
		/// <returns>Nodo em analise, alterado ou nao.</returns>
		private Nodo Remover(Nodo nodo, int elemento)
		{
			if (nodo == null) { Console.WriteLine("Erro ao remover! O elemento nao esta presente na arvore!"); }
			else if (elemento < nodo.Elemento) { nodo.Esq = Remover(nodo.Esq, elemento); }
			else if (elemento > nodo.Elemento) { nodo.Dir = Remover(nodo.Dir, elemento); }
			else
			{
				if (nodo.Dir == null) { nodo = nodo.Esq; } // Sem nodo a direita.
				else if (nodo.Esq == null) { nodo = nodo.Dir; } // Sem nodo a esquerda.
				else { nodo.Esq = Antecessor(nodo, nodo.Esq); } // Nodo a esquerda e nodo a direita.
			}
			
			return nodo;
		}
		
		/// <summary>
		/// Metodo para trocar nodo removido pelo antecessor.
		/// </summary>
		/// <param name="n1">Nodo que teve o elemento removido.</param>
		/// <param name="n2">Nodo da subarvore esquerda.</param>
		/// <returns>Nodo em analise, alterado ou nao.</returns>
		private Nodo Antecessor(Nodo n1, Nodo n2)
		{
			if (n2.Dir != null) // Existe nodo a direita.
			{
				n2.Dir = Antecessor(n1, n2.Dir); // Caminha para direita.
			}
			else // Encontrou o maximo da subarvore esquerda.
			{
				n1.Elemento = n2.Elemento; // Substitui N1 por N2.
				n2 = n2.Esq; // Substitui N2 por N2.ESQ.
			}
			
			return n2;
		}


        public int contagem(Nodo pointer) {

            if(pointer == null)
                return 0;
            else {
                int soma_esq = 0, soma_dir = 0;
                soma_esq = this.contagem(pointer.Esq);
                soma_dir = this.contagem(pointer.Dir);
    
                if(pointer.Pai != null){
                    pointer.Pai.Quantidade += 1 + soma_esq + soma_dir;
                }

                return 1;
            }

        }

        public float soma(Nodo pointer) {

            if(pointer == null){
                return 0;
            }
            else {

                float el_esq = this.soma(pointer.Esq);
                float el_dir = this.soma(pointer.Dir);

               

                if(pointer.Pai != null){
                      pointer.Pai.Soma += pointer.Elemento + el_esq + el_dir;

                }
                



                return pointer.Elemento;
            }

        }

        public float media(Nodo pointer){
                if(pointer == null)
                return 0;
            else {
                float media_esq = 0, media_dir = 0;
                media_esq = this.media(pointer.Esq);
                media_dir = this.media(pointer.Dir);
                pointer.Media = pointer.Soma / pointer.Quantidade;                
                return pointer.Elemento;
            }
        }

    

         public void exibe_media(Nodo pointer){

            if(pointer != null){
                 Console.WriteLine("Nodo ["+pointer.Elemento+"]: Quantidade: "+pointer.Quantidade+" Soma: "+pointer.Soma+". Média  = "+pointer.Media);
                this.exibe_media(pointer.Esq);
                this.exibe_media(pointer.Dir);
            }
          
            
        }

	}
	
	class Program
	{
		public static void Main(string[] args)
		{
			Arvore arvore = new Arvore();
			
			arvore.Inserir(4);
			arvore.Mostrar();
			arvore.Inserir(2);
			arvore.Mostrar();
			arvore.Inserir(6);
	        arvore.Mostrar();
			arvore.Inserir(5);
		    arvore.Mostrar();
		arvore.Inserir(3);
			arvore.Mostrar();
			arvore.Inserir(6);
						
	arvore.Mostrar();
				/* 
			arvore.Remover(6);
			arvore.Mostrar();
			arvore.Remover(2);
			arvore.Mostrar();
			arvore.Remover(4);
	*/		
			arvore.Mostrar();

      

			if (arvore.Pesquisar (11)) {
				Console.WriteLine ("O elemento ja esta presente na arvore!");
				arvore.Remover (11);
			}	
			else 
				Console.WriteLine ("O elemento nao esta presente na arvore!");
			arvore.Mostrar();

            //Média
			arvore.contagem(arvore.Raiz);
			arvore.soma(arvore.Raiz);
			arvore.media(arvore.Raiz);
			arvore.exibe_media(arvore.Raiz);

			
			// Console.Write("Press any key to continue . . . ");
			// Console.ReadKey(true);
		}
	}
}