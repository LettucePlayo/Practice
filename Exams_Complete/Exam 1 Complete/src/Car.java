import java.io.Serializable;
import java.util.Objects;

public class Car implements Vehicle, Serializable, Cloneable {
    private float weight;
    private double price;
    private String producer;

    @Override
    public Object clone() throws CloneNotSupportedException {
        Car car = (Car) super.clone();

        car.weight = weight;
        car.price = price;
        car.producer = producer;

        return car;
    }

    @Override
    public String toString() {
        return "Car{" +
                "weight=" + weight +
                ", price=" + price +
                ", producer='" + producer + '\'' +
                '}';
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Car car = (Car) o;
        return Float.compare(car.weight, weight) == 0 && Double.compare(car.price, price) == 0 && producer.equals(car.producer);
    }

    @Override
    public int hashCode() {
        return Objects.hash(weight, price, producer);
    }

    @Override
    public String infoVehicle() {
        return producer;
    }

    public Car() {
    }

    public float getWeight() {
        return weight;
    }

    public void setWeight(float weight) throws Exception {
        if(weight > 0)
            this.weight = weight;
        else
            throw new Exception();
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) throws Exception {
        if(price > 0)
            this.price = price;
        else
            throw new Exception();
    }

    public String getProducer() {
        return producer;
    }

    public void setProducer(String producer) throws Exception {
        if(producer != null || producer.length() > 1)
            this.producer = producer;
        else
            throw new Exception();
    }
}
