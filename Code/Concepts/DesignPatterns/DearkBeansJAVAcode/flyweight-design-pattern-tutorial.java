//http://www.newthinktank.com/2012/10/flyweight-design-pattern-tutorial/

//FLYWEIGHTTEST.JAVA
// The Flyweight design pattern is used when you need to
// create a large number of similar objects

// To reduce memory this pattern shares Objects that are 
// the same rather than creating new ones

import javax.swing.*;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Graphics;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Random;

public class FlyWeightTest extends JFrame{

	private static final long serialVersionUID = 1L;

	JButton startDrawing;
	
	int windowWidth = 1750;
	int windowHeight = 1000;
	
	// A new rectangle is created only if a new color is needed
	
	Color[] shapeColor = {Color.orange, Color.red, Color.yellow,
			Color.blue, Color.pink, Color.cyan, Color.magenta,
			Color.black, Color.gray};
	
	public static void main(String[] args){
		
		new FlyWeightTest();
		
	}
	
	public FlyWeightTest(){
		
		// Create the frame, position it and handle closing it
		
		this.setSize(windowWidth,windowHeight);
		this.setLocationRelativeTo(null);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setTitle("Flyweight Test");
		
		JPanel contentPane = new JPanel();
		
		contentPane.setLayout(new BorderLayout());
		
		final JPanel  drawingPanel  = new JPanel();
		
		startDrawing = new JButton("Button 1");
		
		contentPane.add(drawingPanel,  BorderLayout.CENTER);
		
		contentPane.add(startDrawing, BorderLayout.SOUTH);
		
		startDrawing.addActionListener(new ActionListener() {
			
			public void actionPerformed(ActionEvent event) {
	            Graphics g = drawingPanel.getGraphics();
	            
	            
	            long startTime = System.currentTimeMillis();
	            
	            
	            for(int i=0; i < 100000; ++i) {
	            	
	            	// 
	            	// Uses rectangles stored in the HashMap to
	            	// speed up the program
	            	
	            	MyRect rect = RectFactory.getRect(getRandColor());
	                rect.draw(g, getRandX(), getRandY(), 
	                		getRandX(), getRandY());
	                
	            	// 
	            	/*
	            	MyRect rect = new MyRect(getRandColor(), getRandX(), getRandY(), getRandX(), getRandY());
	            	rect.draw(g);
	            	*/
	            	

	            	// 
	            	/*
	            	g.setColor(getRandColor());
	            	g.fillRect(getRandX(), getRandY(), getRandX(), getRandY());
	            	*/
	            	
	            	
	            }
	            
	            long endTime = System.currentTimeMillis();

	            System.out.println("That took " + (endTime - startTime) + " milliseconds");
	            
	         }
	      });
		
		this.add(contentPane);
		
		this.setVisible(true);
		
	}
	
	// Picks random x & y coordinates
	
	private int getRandX(){ return (int)(Math.random()*windowWidth); }
	
	private int getRandY(){ return (int)(Math.random()*windowHeight); }
	
	// Picks a random Color from the 9 available
	
	private Color getRandColor(){ 
		Random randomGenerator = new Random();
		
		int randInt = randomGenerator.nextInt(9);
		
		return shapeColor[randInt]; 
		
	}
	
}

//MYRECT.JAVA
import java.awt.*;
public class MyRect {
   private Color color = Color.black;
   private int x, y, x2, y2;
   
   public MyRect(Color color) {
	   
	   this.color = color;
	   
   }
   
   public void draw(Graphics g, int upperX, int upperY, int lowerX, int lowerY) {
	      g.setColor(color);
	      g.fillRect(upperX, upperY, lowerX, lowerY);
   }
   
   /* Original forces creation of a rectangle every time
     
   public MyRect(Color color, int upperX, int upperY, int lowerX, int lowerY) {
      this.color = color;
      this.x = upperX;   
      this.y = upperY;
      this.x2 = lowerX; 
      this.y2 = lowerY;
   }
   
   public void draw(Graphics g) {
      g.setColor(color);
      g.fillRect(x, y, x2, y2);
   }
   */
}

//RECTFACTORY.JAVA
// This factory only creates a new rectangle if it 
// uses a color not previously used

// Intrinsic State: Color
// Extrinsic State: X & Y Values

import java.util.HashMap;
import java.awt.Color;
public class RectFactory {
	
	// The HashMap uses the color as the key for every 
	// rectangle it will make up to 8 total
	
	private static final HashMap<Color, MyRect> rectsByColor = new HashMap<Color, MyRect>();
   
	public static MyRect getRect(Color color) {
		MyRect rect = (MyRect)rectsByColor.get(color);
		
		// Checks if a rectangle with a specific
		// color has been made. If not it makes a
		// new one, otherwise it returns one made already
		
		if(rect == null) {
			rect = new MyRect(color);
			
			// Add new rectangle to HashMap
			
			rectsByColor.put(color, rect);
         
		}
		return rect;
	}
}

//