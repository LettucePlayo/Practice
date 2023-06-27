import java.util.List;

public class VectorThread implements Runnable {
    private List<Vehicle> carList;
    private double avgWeight;

    @Override
    public void run() {
        for(var car : carList)
            avgWeight += ((Car)car).getWeight();
        avgWeight /= carList.size();
    }

    public VectorThread(String file) {
        carList = Utils.readBinaryCars(file);
    }

    public List<Vehicle> getCarList() {
        return carList;
    }

    public void setCarList(List<Vehicle> carList) {
        this.carList = carList;
    }

    public double getAvgWeight() {
        return avgWeight;
    }

    public void setAvgWeight(double avgWeight) {
        this.avgWeight = avgWeight;
    }
}
