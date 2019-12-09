//http://www.newthinktank.com/2012/09/command-design-pattern-tutorial/
//ELECTRONICDEVICE.JAVA
public interface ElectronicDevice {
	
	public void on();
	
	public void off();
	
	public void volumeUp();
	
	public void volumenDown();
	
}
//TELEVISION.JAVA (RECEIVER)
public class Television implements ElectronicDevice {

	private int volume = 0;
	
	public void on() {
		
		System.out.println("TV is on");
		
	}

	public void off() {
		
		System.out.println("TV is off");
		
	}

	public void volumeUp() {
		
		volume++;
		
		System.out.println("TV Volume is at: " + volume);
		
	}

	public void volumenDown() {
		
		volume--;
		
		System.out.println("TV Volume is at: " + volume);
		
	}
	
}
//COMMAND.JAVA
// Each command you want to issue will implement 
// the Command interface

public interface Command {
	
	public void execute();
	
	// You may want to offer the option to undo a command
	
	public void undo();
	
}
//TURNTVON.JAVA (COMMAND)
public class TurnTVOn implements Command {

	ElectronicDevice theDevice;
	
	public TurnTVOn(ElectronicDevice newDevice){
		
		theDevice = newDevice;
		
	}
	
	public void execute() {
		
		theDevice.on();
		
	}

	public void undo() {
		
		theDevice.off();
		
	}
	
}
//TURNTVOFF.JAVA (COMMAND)
public class TurnTVOff implements Command {

	ElectronicDevice theDevice;
	
	public TurnTVOff(ElectronicDevice newDevice){
		
		theDevice = newDevice;
		
	}
	
	public void execute() {
		
		theDevice.off();
		
	}

	// Used if you want to allow for undo
	// Do the opposite of execute()
	
	public void undo() {
		
		theDevice.on();
		
	}
	
}
//TURNTVUP.JAVA (COMMAND)
public class TurnTVUp implements Command {

	ElectronicDevice theDevice;
	
	public TurnTVUp(ElectronicDevice newDevice){
		
		theDevice = newDevice;
		
	}
	
	public void execute() {
		
		theDevice.volumeUp();
		
	}

	public void undo() {
		
		theDevice.volumenDown();
		
	}
	
}
//DEVICEBUTTON.JAVA (INVOKER)
// This is known as the invoker
// It has a method press() that when executed
// causes the execute method to be called

// The execute method for the Command interface then calls 
// the method assigned in the class that implements the
// Command interface

public class DeviceButton{
	
	Command theCommand;
	
	public DeviceButton(Command newCommand){
		
		theCommand = newCommand;
		
	}
	
	public void press(){
		
		theCommand.execute();
		
	}
	
	// Now the remote can undo past commands
	
	public void pressUndo(){
		
		theCommand.undo();
		
	}
	
}
//TVREMOTE.JAVA
public class TVRemote {
	
	public static ElectronicDevice getDevice(){
		
		return new Television();
		
	}
	
}
//PLAYWITHREMOTE.JAVA
import java.util.ArrayList;
import java.util.List;

public class PlayWithRemote{
	
	public static void main(String[] args){
		
		// Gets the ElectronicDevice to use
		
		ElectronicDevice newDevice = TVRemote.getDevice();
		
		// TurnTVOn contains the command to turn on the tv
		// When execute() is called on this command object
		// it will execute the method on() in Television
		
		TurnTVOn onCommand = new TurnTVOn(newDevice);
		
		// Calling the execute() causes on() to execute in Television
		
		DeviceButton onPressed = new DeviceButton(onCommand);
		
		// When press() is called theCommand.execute(); executes
		
		onPressed.press();
		
		//----------------------------------------------------------
		
		// Now when execute() is called off() of Television executes
		
		TurnTVOff offCommand = new TurnTVOff(newDevice);
		
		// Calling the execute() causes off() to execute in Television
		
		onPressed = new DeviceButton(offCommand);
		
		// When press() is called theCommand.execute(); executes
		
		onPressed.press();
		
		//----------------------------------------------------------
		
		// Now when execute() is called volumeUp() of Television executes
		
		TurnTVUp volUpCommand = new TurnTVUp(newDevice);
				
		// Calling the execute() causes volumeUp() to execute in Television
				
		onPressed = new DeviceButton(volUpCommand);
				
		// When press() is called theCommand.execute(); executes
				
		onPressed.press();
		onPressed.press();
		onPressed.press();
		
		//----------------------------------------------------------
		
		// Creating a TV and Radio to turn off with 1 press
		
		Television theTV = new Television();
		
		Radio theRadio = new Radio();
		
		// Add the Electronic Devices to a List
		
		List<ElectronicDevice> allDevices = new ArrayList<ElectronicDevice>();
		
		allDevices.add(theTV);
		allDevices.add(theRadio);
		
		// Send the List of Electronic Devices to TurnItAllOff
		// where a call to run execute() on this function will
		// call off() for each device in the list 
		
		TurnItAllOff turnOffDevices = new TurnItAllOff(allDevices);
		
		// This calls for execute() to run which calls for off() to
		// run for every ElectronicDevice
		
		DeviceButton turnThemOff = new DeviceButton(turnOffDevices);
		
		turnThemOff.press();
		
		//----------------------------------------------------------
		
		/*
		 * It is common to be able to undo a command in a command pattern
		 * To do so, DeviceButton will have a method called undo
		 * Undo() will perform the opposite action that the normal
		 * Command performs. undo() needs to be added to every class
		 * with an execute()
		 */
		
		turnThemOff.pressUndo();
		
		// To undo more than one command add them to a LinkedList
		// using addFirst(). Then execute undo on each item until 
		// there are none left. (This is your Homework)
		
	}
	
}

//RADIO.JAVA (RECEIVER)
public class Radio implements ElectronicDevice {

	private int volume = 0;
	
	public void on() {
		
		System.out.println("Radio is on");
		
	}

	public void off() {
		
		System.out.println("Radio is off");
		
	}

	public void volumeUp() {
		
		volume++;
		
		System.out.println("Radio Volume is at: " + volume);
		
	}

	public void volumenDown() {
		
		volume--;
		
		System.out.println("Radio Volume is at: " + volume);
		
	}
	
}

//TURNITALLOFF.JAVA (COMMAND)
import java.util.List;

public class TurnItAllOff implements Command {
  List<ElectronicDevice> theDevices;
 
  public TurnItAllOff(List<ElectronicDevice> newDevices) {
	  theDevices = newDevices;
  }
 
  public void execute() {
 
    for (ElectronicDevice device : theDevices) {
      device.off();
    }
 
  }

  public void undo() {
	
	for (ElectronicDevice device : theDevices) {
	      device.on();
	    }
	
  }
}

