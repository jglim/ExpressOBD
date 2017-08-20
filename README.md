[![ExpressOBD](https://raw.github.com/jglim/ExpressOBD/master/ExpressOBD.png)](https://raw.github.com/jglim/ExpressOBD/master/ExpressOBD.exe)

# ExpressOBD
_Free control utility for your ELM327-based OBD2 device to clear MIL ("Check Engine Light")_

## Usage

1. [**Download**](https://raw.github.com/jglim/ExpressOBD/master/ExpressOBD.exe) and run ExpressOBD
2. Connect your ELM327-based OBD2 device to your computer and to the vehicle. Start the vehicle.
4. In ExpressOBD, select the serial port of your device. 
5. Press `Connect`. If a connection is successfully established, the `Reset Errors` button will now be available.
6. Press `Reset Errors` and acknowledge the reset. Restart the vehicle and the MIL should be removed.

---

## Troubleshooting & FAQ

**Is this really free?**

_Yes - free (as in beer) and also open source (MIT). This utility is built to enable auto enthusiasts and workshops to quickly and easily clear the MIL light. 
ExpressOBD may also be of use to owners of "knockoff" ELM327 devices _(ebay, Aliexpress)_ that do not trust the provided software. Note that drivers are still required to interface with the hardware._


**Does this actually solve the vehicle's problem?**

_No. Make sure that the issue that initiated the MIL has been completely resolved before resetting the MIL._ 


**There are no serial ports listed in ExpressOBD**

_Ensure that corresponding serial drivers are installed. Your vendor should provide the corresponding drivers. Windows Update may also be able to find the appropriate drivers._


**Which serial port should I select?**

_It is usually the largest COM number, but this can be confirmed by unplugging/replugging the device to see if the entry disappears/reappears._


**Every serial port throws a "Serial Timeout: Port or baud rate may be incorrectly set" error. What gives?**

_Check with your device's vendor on the baud rate settings. The default communications speed (baud rate) for most ELM327-based devices is set at 38400. Another possibility is that your device's serial drivers are not installed yet._


**Why is there an "ECU not detected!" error when attempting to connect?**

_Is your vehicle turned on? At a minimum, the ignition switch should be turned to provide electricity._

_Another possibility is that the OBD2 connection is not properly mated. This can be verified by the "Vehicle Voltage" in the status log, where the expected value should be around 12V._


**"No compatible ELM327 device"?**

_ExpressOBD supports all serial devices conforming to the ELM327 protocol, even the "1.5" knockoffs. There are other devices that plug to the OBD2 port but do not use the ELM327 protocol, which ExpressOBD does not support._


**The MIL ("Check Engine Light") still remains even after the reset. Why is that so?**

_Some error codes including Mode 0A (Permanent Trouble Codes) are unaffected by the reset process and can only be cleared by ECU._
---

# How does ExpressOBD work?

In brief, ExpressOBD connects to the ELM327 based device and issues the `Mode 04` command. The command, as described by the datasheet, does the following:

- Reset MIL ("Malfunction Indicator Light" or more commonly, "Check Engine Light")
- Reset number of trouble codes
- Erase any Diagnostic Trouble Codes (DTCs)
- Erase any stored freeze frame data
- Erase the DTC that initiated the freeze frame
- Erase all oxygen sensor test data
- Erase Mode 06 and 07 information

This action is not specific to ELM327 or ExpressOBD. Tools which reset the MIL will also perform these tasks.

The commands sent to ELM327 (in multiple stages) are:

```
ATWS    // Warm Start
ATZ     // Reset All
ATE0    // Echo Off
ATL0    // Linefeeds off
ATH1    // Headers ON
ATSP0   // Set Protocol to (0) (AUTO)
ATI     // Print Version ID
AT@1    // Print Device Description
ATRV    // Print Input Voltage
0100    // OBD: Read Supported Codes 01-20 (For connecting to ECU)
ATDP    // Print Current Protocol
0101    // OBD: Read MIL status and test availability
04      // Reset MIL
```

---

# License
**Icons:** [famfamfam.com/lab/icons/silk](http://famfamfam.com/lab/icons/silk/)
**ExpressOBD:** MIT - Refer to [LICENSE](https://raw.github.com/jglim/ExpressOBD/master/LICENSE) file for additional details
