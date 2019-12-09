//http://www.newthinktank.com/2012/09/prototype-design-pattern-tutorial/
//ANIMAL.JAVA
// By making this class cloneable you are telling Java
// that it is ok to copy instances of this class
// These instance copies have different results when
// System.identityHashCode(System.identityHashCode(bike))
// is called 

public interface Animal extends Cloneable {
	
	public Animal makeCopy();
	
}
//SHEEP.JAVA
public class Sheep implements Animal {

	public Sheep(){
		
		System.out.println("Sheep is Made");
		
	}
	
	public Animal makeCopy() {
		
		System.out.println("Sheep is Being Made");
		
		Sheep sheepObject = null;
		
		try {
			
			// Calls the Animal super classes clone()
			// Then casts the results to Sheep
			
			sheepObject = (Sheep) super.clone();
			
		}
		
		// If Animal didn't extend Cloneable this error 
		// is thrown
		
		catch (CloneNotSupportedException e) {
			  
			System.out.println("The Sheep was Turned to Mush");
			
			e.printStackTrace();
			  
		 }
		
		return sheepObject;
	}
	
	public String toString(){
		
		return "Dolly is my Hero, Baaaaa";
		
	}
	
}
//public class Sheep implements Animal {

	public Sheep(){
		
		System.out.println("Sheep is Made");
		
	}
	
	public Animal makeCopy() {
		
		System.out.println("Sheep is Being Made");
		
		Sheep sheepObject = null;
		
		try {
			
			// Calls the Animal super classes clone()
			// Then casts the results to Sheep
			
			sheepObject = (Sheep) super.clone();
			
		}
		
		// If Animal didn't extend Cloneable this error 
		// is thrown
		
		catch (CloneNotSupportedException e) {
			  
			System.out.println("The Sheep was Turned to Mush");
			
			e.printStackTrace();
			  
		 }
		
		return sheepObject;
	}
	
	public String toString(){
		
		return "Dolly is my Hero, Baaaaa";
		
	}
	
}

//CLONEFACTORY.JAVA
public class CloneFactory {
	
	// Receives any Animal, or Animal subclass and
	// makes a copy of it and stores it in its own
	// location in memory
	
	// CloneFactory has no idea what these objects are
	// except that they are subclasses of Animal
	
	public Animal getClone(Animal animalSample) {
		
		// Because of Polymorphism the Sheeps makeCopy()
		// is called here instead of Animals
		
		return animalSample.makeCopy();
		
	}
	
}

//TESTCLONING.JAVA
public class TestCloning {
	
	public static void main(String[] args){
		
		// Handles routing makeCopy method calls to the 
		// right subclasses of Animal
		
		CloneFactory animalMaker = new CloneFactory();
		
		// Creates a new Sheep instance
		
		Sheep sally = new Sheep();
		
		// Creates a clone of Sally and stores it in its own
		// memory location
		
		Sheep clonedSheep = (Sheep) animalMaker.getClone(sally);
		
		// These are exact copies of each other
		
		System.out.println(sally);
		
		System.out.println(clonedSheep);
		
		System.out.println("Sally HashCode: " + System.identityHashCode(System.identityHashCode(sally)));
		
		System.out.println("Clone HashCode: " + System.identityHashCode(System.identityHashCode(clonedSheep)));
	}
	
}

