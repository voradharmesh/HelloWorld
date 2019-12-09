//http://www.newthinktank.com/2012/09/builder-design-pattern-tutorial/
//RobotPlan.java
// This is the interface that will be returned from the builder

public interface RobotPlan{
	
	public void setRobotHead(String head);
	
	public void setRobotTorso(String torso);
	
	public void setRobotArms(String arms);
	
	public void setRobotLegs(String legs);
	
}

//Robot.java
// The concrete Robot class based on the RobotPlan interface

public class Robot implements RobotPlan{

	private String robotHead;
	private String robotTorso;
	private String robotArms;
	private String robotLegs;
	
	public void setRobotHead(String head) {
		
		robotHead = head;
		
	}
	
	public String getRobotHead(){ return robotHead; }

	
	public void setRobotTorso(String torso) {
		
		robotTorso = torso;
		
	}
	
	public String getRobotTorso(){ return robotTorso; }

	
	public void setRobotArms(String arms) {
		
		robotArms = arms;
		
	}
	
	public String getRobotArms(){ return robotArms; }

	
	public void setRobotLegs(String legs) {
		
		robotLegs = legs;
		
	}
	
	public String getRobotLegs(){ return robotLegs; }
	
	
	
}
//RobotBuilder.java
// Defines the methods needed for creating parts 
// for the robot

public interface RobotBuilder {
	
	public void buildRobotHead();
	
	public void buildRobotTorso();
	
	public void buildRobotArms();
	
	public void buildRobotLegs();
	
	public Robot getRobot();
	
}
//OldRobotBuilder.java
// The concrete builder class that assembles the parts 
// of the finished Robot object

public class OldRobotBuilder implements RobotBuilder {

	private Robot robot;
	
	public OldRobotBuilder() {
		
		this.robot = new Robot();
		
	}
	
	public void buildRobotHead() {
		
		robot.setRobotHead("Tin Head");
		
	}

	public void buildRobotTorso() {
		
		robot.setRobotTorso("Tin Torso");
		
	}

	public void buildRobotArms() {
		
		robot.setRobotArms("Blowtorch Arms");
		
	}

	public void buildRobotLegs() {
		
		robot.setRobotLegs("Rollar Skates");
		
	}

	public Robot getRobot() {
		
		return this.robot;
	}
	
	
	
}

//RobotEngineer.java
// The director / engineer class creates a Robot using the
// builder interface that is defined (OldRobotBuilder)

public class RobotEngineer {
	
	private RobotBuilder robotBuilder;
	
	// OldRobotBuilder specification is sent to the engineer
	
	public RobotEngineer(RobotBuilder robotBuilder){
		
		this.robotBuilder = robotBuilder;
		
	}
	
	// Return the Robot made from the OldRobotBuilder spec
	
	public Robot getRobot(){
		
		return this.robotBuilder.getRobot();
		
	}
	
	// Execute the methods specific to the RobotBuilder 
	// that implements RobotBuilder (OldRobotBuilder)
	
	public void makeRobot() {
		
		this.robotBuilder.buildRobotHead();
		this.robotBuilder.buildRobotTorso();
		this.robotBuilder.buildRobotArms();
		this.robotBuilder.buildRobotLegs();
		
	}
	
}
//TestRobotBuilder.java
public class TestRobotBuilder {
	
	public static void main(String[] args){
		
		// Get a RobotBuilder of type OldRobotBuilder
		
		RobotBuilder oldStyleRobot = new OldRobotBuilder();
		
		// Pass the OldRobotBuilder specification to the engineer
		
		RobotEngineer robotEngineer = new RobotEngineer(oldStyleRobot);
		
		// Tell the engineer to make the Robot using the specifications
		// of the OldRobotBuilder class
		
		robotEngineer.makeRobot();
		
		// The engineer returns the right robot based off of the spec
		// sent to it on line 11
		
		Robot firstRobot = robotEngineer.getRobot();
		
		System.out.println("Robot Built");
		
		System.out.println("Robot Head Type: " + firstRobot.getRobotHead());
		
		System.out.println("Robot Torso Type: " + firstRobot.getRobotTorso());
		
		System.out.println("Robot Arm Type: " + firstRobot.getRobotArms());
		
		System.out.println("Robot Leg Type: " + firstRobot.getRobotLegs());
		
	}
	
}
