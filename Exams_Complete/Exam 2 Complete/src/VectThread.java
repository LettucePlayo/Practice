import java.util.List;

public class VectThread implements Runnable{
    public List<ElectronicDevices> phonesList;
    public double avgWeight;

    public VectThread(String filename) {
        this.phonesList = Utils.readBinaryPhones(filename);
    }

    public List<ElectronicDevices> getPhonesList() {
        return phonesList;
    }

    public double getAvgWeight() {
        return avgWeight;
    }

    @Override
    public void run() {
        for(ElectronicDevices phone : phonesList) {
            avgWeight += ((Phone) phone).getWeight();
        }
        avgWeight /= phonesList.size();
    }
}
