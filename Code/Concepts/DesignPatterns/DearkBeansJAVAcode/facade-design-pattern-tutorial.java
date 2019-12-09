//http://www.newthinktank.com/2012/09/facade-design-pattern-tutorial/

//WELCOMETOBANK.JAVA
public class WelcomeToBank{
	
	public WelcomeToBank() {
		
		System.out.println("Welcome to ABC Bank");
		System.out.println("We are happy to give you your money if we can find it\n");
		
		
	}
	
}

//ACCOUNTNUMBERCHECK.JAVA
public class AccountNumberCheck{
	
	private int accountNumber = 12345678;
	
	public int getAccountNumber() { return accountNumber; }
	
	public boolean accountActive(int acctNumToCheck){
		
		if(acctNumToCheck == getAccountNumber()) {
			
			return true;
			
		} else {
			
			return false;
			
		}
		
	}
	
}

//SECURITYCODECHECK.JAVA
public class SecurityCodeCheck {
	
	private int securityCode = 1234;
	
	public int getSecurityCode() { return securityCode; }
	
	public boolean isCodeCorrect(int secCodeToCheck){
		
		if(secCodeToCheck == getSecurityCode()) {
			
			return true;
			
		} else {
			
			return false;
			
		}
		
	}
	
}
//FUNDSCHECK.JAVA
public class FundsCheck {
	
	private double cashInAccount = 1000.00;
	
	public double getCashInAccount() { return cashInAccount; }
	
	public void decreaseCashInAccount(double cashWithdrawn) { cashInAccount -= cashWithdrawn; }
	
	public void increaseCashInAccount(double cashDeposited) { cashInAccount += cashDeposited; }
	
	public boolean haveEnoughMoney(double cashToWithdrawal) {
		
		if(cashToWithdrawal > getCashInAccount()) {
			
			System.out.println("Error: You don't have enough money");
			System.out.println("Current Balance: " + getCashInAccount());
			
			return false;
			
		} else {
			
			decreaseCashInAccount(cashToWithdrawal);
			
			System.out.println("Withdrawal Complete: Current Balance is " + getCashInAccount());
			
			return true;
			
		}
		
	}
	
	public void makeDeposit(double cashToDeposit) {
		
		increaseCashInAccount(cashToDeposit);
		
		System.out.println("Deposit Complete: Current Balance is " + getCashInAccount());
		
	}
	
}

//BANKACCOUNTFACADE.JAVA
// The Facade Design Pattern decouples or separates the client 
// from all of the sub components

// The Facades aim is to simplify interfaces so you don't have 
// to worry about what is going on under the hood

public class BankAccountFacade {
	
	private int accountNumber;
	private int securityCode;
	
	AccountNumberCheck acctChecker;
	SecurityCodeCheck codeChecker;
	FundsCheck fundChecker;
	
	WelcomeToBank bankWelcome;
	
	public BankAccountFacade(int newAcctNum, int newSecCode){
		
		accountNumber = newAcctNum;
		securityCode = newSecCode;
		
		bankWelcome = new WelcomeToBank();
		
		acctChecker = new AccountNumberCheck();
		codeChecker = new SecurityCodeCheck();
		fundChecker = new FundsCheck();
		
	}
	
	public int getAccountNumber() { return accountNumber; }
	
	public int getSecurityCode() { return securityCode; }
	
	
	public void withdrawCash(double cashToGet){
		
		if(acctChecker.accountActive(getAccountNumber()) &&
				codeChecker.isCodeCorrect(getSecurityCode()) &&
				fundChecker.haveEnoughMoney(cashToGet)) {
					
					System.out.println("Transaction Complete\n");
					
				} else {
					
					System.out.println("Transaction Failed\n");
					
				}
		
	}
	
	
	public void depositCash(double cashToDeposit){
		
		if(acctChecker.accountActive(getAccountNumber()) &&
				codeChecker.isCodeCorrect(getSecurityCode())) {
			
					fundChecker.makeDeposit(cashToDeposit);
					
					System.out.println("Transaction Complete\n");
					
				} else {
					
					System.out.println("Transaction Failed\n");
					
				}
		
	}
	
}

//TESTBANKACCOUNT.JAVA
public class TestBankAccount {
	
	public static void main(String[] args){
		
		BankAccountFacade accessingBank = new BankAccountFacade(12345678, 1234);
		
		accessingBank.withdrawCash(50.00);
		
		accessingBank.withdrawCash(990.00);
		
	}
	
}

