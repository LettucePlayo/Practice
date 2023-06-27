import java.io.Serial;
import java.io.Serializable;
import java.util.Objects;

public class Phone implements ElectronicDevices, Cloneable, Serializable {
    @Serial
    private static final long serialVersionUID = 0;
    private float weight;
    private double diagonal;
    private String producer;

    @Override
    public String infoDevice() {
        return producer;
    }

    public Phone() {}

    public float getWeight() {
        return weight;
    }

    public void setWeight(float weight) throws Exception {
        if(weight <= 0)
            throw new Exception();
        this.weight = weight;
    }

    public double getDiagonal() {
        return diagonal;
    }

    public void setDiagonal(double diagonal) throws Exception {
        if(diagonal <= 0)
            throw new Exception();
        this.diagonal = diagonal;
    }

    public String getProducer() {
        return producer;
    }

    public void setProducer(String producer) throws Exception {
        if(producer == null || producer.length() == 0)
            throw new Exception();
        this.producer = producer;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Phone phone = (Phone) o;
        return Float.compare(phone.weight, weight) == 0 && Double.compare(phone.diagonal, diagonal) == 0 && producer.equals(phone.producer);
    }

    @Override
    public int hashCode() {
        return Objects.hash(weight, diagonal, producer);
    }

    @Override
    public Object clone() throws CloneNotSupportedException {
        Phone phone = (Phone) super.clone();
        try {
            phone.setWeight(this.weight);
            phone.setDiagonal(this.diagonal);
            phone.setProducer(this.producer);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
        return phone;
    }

    @Override
    public String toString() {
        return "Phone{" +
                "weight=" + weight +
                ", diagonal=" + diagonal +
                ", producer='" + producer + '\'' +
                '}';
    }
}
