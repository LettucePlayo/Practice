import java.io.Serializable;
import java.util.Date;

public class HumanJob extends Human implements Work, Comparable<HumanJob>, Serializable, Cloneable{
	
	public enum Job {CHILD, STUDENT, ADULT};
	
	private Job job;

	

	@Override
	public String toString() {
		return this.getNume() + " " + this.getBirthday() + " " + this.getId() + " " + this.getJob(); 
	}

	public HumanJob(String nume, Date birthday, int id, HumanJob.Job job) {
		super(nume, birthday, id);
		this.job = job;
	}

	public Job getJob() {
		return job;
	}

	public void setJob(Job job) {
		this.job = job;
	}

	

	@Override
	public void doJob() {
		System.out.println("Job is being done");
	}
	
	@Override
	public int compareTo(HumanJob o) {
		if( this.getId()==o.getId())
			return 0;
		if (this.getId()<o.getId())
			return -1;
		
		return 1;
		
	}
	@Override
	protected Object clone() throws CloneNotSupportedException {
		HumanJob clone=(HumanJob) super.clone();
		clone.job=this.job;
		return clone;
	}
	@Override
	public boolean equals(Object obj) {
		if (this == obj) {
	        return true;
	    }
	    if (obj == null || getClass() != obj.getClass()) {
	        return false;
	    }
	    HumanJob other = (HumanJob) obj;
	    return this.getId() == other.getId();
	}
	@Override
	public int hashCode() {
		// TODO Auto-generated method stub
		return super.hashCode();
	}

	

}
