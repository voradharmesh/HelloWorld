//http://www.newthinktank.com/2012/10/proxy-design-pattern-tutorial/

//ATMMACHINE.JAVA
public class ATMMachine implements GetATMData{
	
	
	public ATMState getYesCardState() { return hasCard; }
	public ATMState getNoCardState() { return noCard; }
	public ATMState getHasPin() { return hasCorrectPin; }
	public ATMState getNoCashState() { return atmOutOfMoney; }
	
	// NEW STUFF
	
	public ATMState getATMState() { return atmState; }
	public int getCashInMachine() { return cashInMachine; }
}

//GETATMDATA.JAVA
// This interface will contain just those methods
// that you want the proxy to provide access to

public interface GetATMData
{
  public ATMState getATMState();
  public int getCashInMachine();
}

//ATMPROXY.JAVA
// In this situation the proxy both creates and destroys
// an ATMMachine Object

public class ATMProxy implements GetATMData {

	// Allows the user to access getATMState in the 
	// Object ATMMachine
	
	public ATMState getATMState() {
		
		ATMMachine realATMMachine = new ATMMachine();
		
		return realATMMachine.getATMState();
	}

	// Allows the user to access getCashInMachine 
	// in the Object ATMMachine
	
	public int getCashInMachine() {
		
		ATMMachine realATMMachine = new ATMMachine();
		
		return realATMMachine.getCashInMachine();
		
	}
	
}
//TESTATMMACHINE.JAVA
public class TestATMMachine {
	
	public static void main(String[] args){
		
		ATMMachine atmMachine = new ATMMachine();
		
		atmMachine.insertCard();
		
		atmMachine.ejectCard();
		
		atmMachine.insertCard();
		
		atmMachine.insertPin(1234);
		
		atmMachine.requestCash(2000);
		
		atmMachine.insertCard();
		
		atmMachine.insertPin(1234);
		
		// NEW STUFF : Proxy Design Pattern Code
		// The interface limits access to just the methods you want
		// made accessible

		GetATMData realATMMachine = new ATMMachine();
		
		GetATMData atmProxy = new ATMProxy();
		
		System.out.println("\nCurrent ATM State " + atmProxy.getATMState());
		
		System.out.println("\nCash in ATM Machine $" + atmProxy.getCashInMachine());
		
		// The user can't perform this action because ATMProxy doesn't
		// have access to that potentially harmful method
		// atmProxy.setCashInMachine(10000);
		
	}
	
}
//ATMState.java
public interface ATMState {
	
	void insertCard();
	void ejectCard();
	void insertPin(int pinEntered);
	void requestCash(int cashToWithdraw);
	
}

