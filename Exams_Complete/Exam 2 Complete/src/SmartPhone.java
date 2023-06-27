public class SmartPhone extends Phone{
    public int batteryDuration;

    @Override
    public String infoDevice() {
        return String.valueOf(batteryDuration);
    }

    public int getBatteryDuration() {
        return batteryDuration;
    }

    public void setBatteryDuration(int batteryDuration) throws Exception {
        if(batteryDuration <= 0)
            throw new Exception();
        this.batteryDuration = batteryDuration;
    }
}
