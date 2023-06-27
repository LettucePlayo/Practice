import java.util.Date;

public class Human {
	
	private String nume;
	private Date birthday;
	private int id;
	private static int counter = 0;
	public String getNume() {
		return nume;
	}
	public void setNume(String nume) {
		this.nume = nume;
	}
	public Date getBirthday() {
		return birthday;
	}
	public void setBirthday(Date birthday) {
		this.birthday = birthday;
	}
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public static int getCounter() {
		return counter;
	}
	public Human(String nume, Date birthday, int id) {
		super();
		this.nume = nume;
		this.birthday = birthday;
		this.id = counter;
		counter++;
	}
	
	
	
	

}
