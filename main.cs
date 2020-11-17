using System;

/*clases que tienen poco metodos pero pueden servir a subclases que no pertenezcan a una superclase. 
Se puedeb incluir clases que no tengan relacion con las demas por su naturaleza de existencia, del mismo modo no heredan de ninguna pero pueden adoptar metodos que sirven a la superclase, es por ello mover los metodos necesarios que sirvan a la cadena de hrencia y para los que no, a una clase abstracta para compartirlas
*/ 
class MainClass {
  public static void Main (string[] args) {
    Caballo miBabieca = new Caballo("Babieca");
		Humano miJuan = new Humano("Juan");
		Gorila miGorila = new Gorila("Gorila");
    Ballena miBallena = new Ballena("Moby");
    Lagartija miLagartija = new Lagartija("Igor");

    miLagartija.getNombre();
    miLagartija.respirar();
    miJuan.getNombre();
    miJuan.respirar();
  }
}

abstract class Animales{
  //este metodo existia en la clase mamiferos, la quitamos para colocarla en la clase abstracta
  public void respirar(){
		Console.WriteLine("Soy capaz de respirar");
	}
  //en caso cree un metodo en la clase abstracta de igual nombre al metodo de una superclase pero el contenido sea diferentem debo añadirle a palabra abstract
  public abstract void getNombre();
}

//creacion de interfaces
//obliga a seguir parametros cuando se crean nuevas clases. Interface es un conjunto de directrices que deben cumplir las clases
//en las interfaces no hay codigo solo se declaran, no hay llaves, no indicar public ni private 
interface IMamiferoTerrestre{
  int numeroPatas();
}  

class Mamiferos:Animales{//superclase, hereda metodos de la clase abstracta por lo que su subclases heredaran tambien esos metodos
  private string nombreSerVivo;
  
  //constructor
	public Mamiferos(string nombre){
		nombreSerVivo = nombre;
	}

	public void cuidarCrias(){
		Console.WriteLine("Soy capaz de cuidad crías");
	}
	public virtual void pensar(){
	  Console.WriteLine("Pensamiento básico e instintivo");
	}
  //añadir la palabra override el metodo que estamos heredado de la clase abstracta
	public override void getNombre(){
		Console.WriteLine("El nombre del mamífero es: " + nombreSerVivo);
	}
  
}

//subclases
class Lagartija:Animales{
  private string nombreReptil;

  public Lagartija(string nombre){
    nombreReptil = nombre;
  }
  //sobreescribir el metodo para separarla del metodo de clase abstracta
  public override void getNombre(){
    Console.WriteLine("El nombre del reptil es: " + nombreReptil);
  }
}

class Ballena:Mamiferos{
  public Ballena(string nombreBallena):base(nombreBallena){}
  public void nadar(){
    Console.WriteLine("Soy capaz de nadar");
  }
}
//en la clase caballo se agrego despues del nombre de la superclase el nombre de la interface, se dee respetar ese orden en c#
class Caballo:Mamiferos, IMamiferoTerrestre{
	public Caballo(string nombreCaballo):base(nombreCaballo){}
	public void galopar(){
		Console.WriteLine("Soy capaz de galopar");
	}
  public int numeroPatas(){
    return 4;
  }
}
class Humano:Mamiferos{
	public Humano(string nombreHumano):base(nombreHumano){}
	public override void pensar(){
		Console.WriteLine("Soy capaz de pensar");
	}
}
class Gorila:Mamiferos, IMamiferoTerrestre{
	public Gorila(string nombreGorila):base(nombreGorila){}
	public void trepar(){
		Console.WriteLine("Soy capaz de trepar");
	}
  public override void pensar(){
    Console.WriteLine("Pensamiento animal");
  }
  public int numeroPatas(){
    return 2;
  }
}
