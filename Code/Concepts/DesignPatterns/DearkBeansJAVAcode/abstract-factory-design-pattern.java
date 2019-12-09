//http://www.newthinktank.com/2012/09/abstract-factory-design-pattern/
//EnemyShipTesting.java
public class EnemyShipTesting {
	
public static void main(String[] args) {
		
		// EnemyShipBuilding handles orders for new EnemyShips
		// You send it a code using the orderTheShip method &
		// it sends the order to the right factory for creation
	
		EnemyShipBuilding MakeUFOs = new UFOEnemyShipBuilding();
 
		EnemyShip theGrunt = MakeUFOs.orderTheShip("UFO");
		System.out.println(theGrunt + "\n");
		
		EnemyShip theBoss = MakeUFOs.orderTheShip("UFO BOSS");
		System.out.println(theBoss + "\n");
 
	}
	
}
//EnemyShipBuilding.java
public abstract class EnemyShipBuilding {
	
	// This acts as an ordering mechanism for creating
	// EnemyShips that have a weapon, engine & name
	// & nothing else
	
	// The specific parts used for engine & weapon depend
	// upon the String that is passed to this method
 
	protected abstract EnemyShip makeEnemyShip(String typeOfShip);
 
	// When called a new EnemyShip is made. The specific parts
	// are based on the String entered. After the ship is made
	// we execute multiple methods in the EnemyShip Object
	
	public EnemyShip orderTheShip(String typeOfShip) {
		EnemyShip theEnemyShip = makeEnemyShip(typeOfShip);
		
		theEnemyShip.makeShip();
		theEnemyShip.displayEnemyShip();
		theEnemyShip.followHeroShip();
		theEnemyShip.enemyShipShoots();
		
		return theEnemyShip;
		
	}
}
//UFOEnemyShipBuilding.java
// This is the only class that needs to change, if you
// want to determine which enemy ships you want to
// provide as an option to build

public class UFOEnemyShipBuilding extends EnemyShipBuilding {

	protected EnemyShip makeEnemyShip(String typeOfShip) {
		EnemyShip theEnemyShip = null;
		
		// If UFO was sent grab use the factory that knows
		// what types of weapons and engines a regular UFO
		// needs. The EnemyShip object is returned & given a name
		
		if(typeOfShip.equals("UFO")){
			EnemyShipFactory shipPartsFactory = new UFOEnemyShipFactory();
			theEnemyShip = new UFOEnemyShip(shipPartsFactory);
			theEnemyShip.setName("UFO Grunt Ship");
			
		} else 
			
		// If UFO BOSS was sent grab use the factory that knows
		// what types of weapons and engines a Boss UFO
		// needs. The EnemyShip object is returned & given a name
			
		if(typeOfShip.equals("UFO BOSS")){
			EnemyShipFactory shipPartsFactory = new UFOBossEnemyShipFactory();
			theEnemyShip = new UFOBossEnemyShip(shipPartsFactory);
			theEnemyShip.setName("UFO Boss Ship");
			
		} 
		
		return theEnemyShip;
	}
}
//EnemyShipFactory.java
// With an Abstract Factory Pattern you won't
// just build ships, but also all of the components
// for the ships

// Here is where you define the parts that are required
// if an object wants to be an enemy ship

public interface EnemyShipFactory{
	
	public ESWeapon addESGun();
	public ESEngine addESEngine();
	
}

//UFOEnemyShipFactory.java
// This factory uses the EnemyShipFactory interface
// to create very specific UFO Enemy Ship

// This is where we define all of the parts the ship
// will use by defining the methods implemented
// being ESWeapon and ESEngine

// The returned object specifies a specific weapon & engine

public class UFOEnemyShipFactory implements EnemyShipFactory{

	// Defines the weapon object to associate with the ship
	
	public ESWeapon addESGun() {
		return new ESUFOGun(); // Specific to regular UFO
	}

	// Defines the engine object to associate with the ship
	
	public ESEngine addESEngine() {
		return new ESUFOEngine(); // Specific to regular UFO
	}
}

//UFOBossEnemyShipFactory.java
// This factory uses the EnemyShipFactory interface
// to create very specific UFO Enemy Ship

// This is where we define all of the parts the ship
// will use by defining the methods implemented
// being ESWeapon and ESEngine

// The returned object specifies a specific weapon & engine

public class UFOBossEnemyShipFactory implements EnemyShipFactory{

	// Defines the weapon object to associate with the ship
	
	public ESWeapon addESGun() {
		return new ESUFOBossGun(); // Specific to Boss UFO
	}

	// Defines the engine object to associate with the ship
	
	public ESEngine addESEngine() {
		return new ESUFOBossEngine(); // Specific to Boss UFO
	}

}
//EnemyShip.java
public abstract class EnemyShip {
	
	private String name;
	
	// Newly defined objects that represent weapon & engine
	// These can be changed easily by assigning new parts 
	// in UFOEnemyShipFactory or UFOBossEnemyShipFactory
	
	ESWeapon weapon;
	ESEngine engine;
	
	public String getName() { return name; }
	public void setName(String newName) { name = newName; }
	
	abstract void makeShip();
	
	// Because I defined the toString method in engine
	// when it is printed the String defined in toString goes
	// on the screen
	
	public void followHeroShip(){
		
		System.out.println(getName() + " is following the hero at " + engine );
		
	}
	
	public void displayEnemyShip(){
		
		System.out.println(getName() + " is on the screen");
		
	}
	
	public void enemyShipShoots(){
		
		System.out.println(getName() + " attacks and does " + weapon);
		
	}
	
	// If any EnemyShip object is printed to screen this shows up
	
	public String toString(){
		
		String infoOnShip = "The " + name + " has a top speed of " + engine + 
				" and an attack power of " + weapon;
		
		return infoOnShip;
		
	}
	
}
//UFOEnemyShip.java
public class UFOEnemyShip extends EnemyShip{
	
	// We define the type of ship we want to create
	// by stating we want to use the factory that 
	// makes enemy ships
	
	EnemyShipFactory shipFactory;
	
	// The enemy ship required parts list is sent to 
	// this method. They state that the enemy ship
	// must have a weapon and engine assigned. That 
	// object also states the specific parts needed
	// to make a regular UFO versus a Boss UFO
	
	public UFOEnemyShip(EnemyShipFactory shipFactory){
		
		this.shipFactory = shipFactory;
		
	}

	// EnemyShipBuilding calls this method to build a 
	// specific UFOEnemyShip
	
	void makeShip() {
		
		System.out.println("Making enemy ship " + getName());
		
		// The specific weapon & engine needed were passed in
		// shipFactory. We are assigning those specific part
		// objects to the UFOEnemyShip here
		
		weapon = shipFactory.addESGun();
		engine = shipFactory.addESEngine();
		
	}
	
}

//UFOBossEnemyShip.java
public class UFOBossEnemyShip extends EnemyShip{
	
	// We define the type of ship we want to create
	// by stating we want to use the factory that 
	// makes enemy ships
	
	EnemyShipFactory shipFactory;
	
	// The enemy ship required parts list is sent to 
	// this method. They state that the enemy ship
	// must have a weapon and engine assigned. That 
	// object also states the specific parts needed
	// to make a Boss UFO versus a Regular UFO
	
	public UFOBossEnemyShip(EnemyShipFactory shipFactory){
		
		this.shipFactory = shipFactory;
		
	}
	
	// EnemyShipBuilding calls this method to build a 
	// specific UFOBossEnemyShip

	void makeShip() {
		
		// TODO Auto-generated method stub
		
		System.out.println("Making enemy ship " + getName());
		
		// The specific weapon & engine needed were passed in
		// shipFactory. We are assigning those specific part
		// objects to the UFOBossEnemyShip here
		
		weapon = shipFactory.addESGun();
		engine = shipFactory.addESEngine();
		
	}
	
}
//ESEngine.java
// Any part that implements the interface ESEngine
// can replace that part in any ship

public interface ESEngine{

	// User is forced to implement this method
	// It outputs the string returned when the 
	// object is printed
	
	public String toString();

}

//ESWeapon.java
// Any part that implements the interface ESWeapon
// can replace that part in any ship

public interface ESWeapon{
	
	// User is forced to implement this method
	// It outputs the string returned when the 
	// object is printed

	public String toString();

}
//ESUFOGun.java
// Here we define a basic component of a space ship
// Any part that implements the interface ESWeapon
// can replace that part in any ship

public class ESUFOGun implements ESWeapon{
	
	// EnemyShip contains a reference to the object
	// ESWeapon. It is stored in the field weapon
	
	// The Strategy design pattern is being used here
	
	// When the field that is of type ESUFOGun is printed 
	// the following shows on the screen
	
	public String toString(){
		return "20 damage";
	}
	
}

//ESUFOEngine.java
// Here we define a basic component of a space ship
// Any part that implements the interface ESEngine
// can replace that part in any ship

public class ESUFOEngine implements ESEngine{
	
	// EnemyShip contains a reference to the object
	// ESWeapon. It is stored in the field weapon
		
	// The Strategy design pattern is being used here
		
	// When the field that is of type ESUFOGun is printed 
	// the following shows on the screen
	
	public String toString(){
		return "1000 mph";
	}
	
}
//ESUFOBossGun.java
// Here we define a basic component of a space ship
// Any part that implements the interface ESWeapon
// can replace that part in any ship

public class ESUFOBossGun implements ESWeapon{
	
	// EnemyShip contains a reference to the object
	// ESWeapon. It is stored in the field weapon
		
	// The Strategy design pattern is being used here
		
	// When the field that is of type ESUFOGun is printed 
	// the following shows on the screen
	
	public String toString(){
		return "40 damage";
	}
	
}
//ESUFOBossEngine.java
// Here we define a basic component of a space ship
// Any part that implements the interface ESEngine
// can replace that part in any ship

public class ESUFOBossEngine implements ESEngine{
	
	// EnemyShip contains a reference to the object
	// ESWeapon. It is stored in the field weapon
			
	// The Strategy design pattern is being used here
			
	// When the field that is of type ESUFOGun is printed 
	// the following shows on the screen
	
	public String toString(){
		return "2000 mph";
	}
	
}
