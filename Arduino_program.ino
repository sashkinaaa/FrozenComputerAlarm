char incomingChar = 0; // for incoming serial data
int NoSignalCounter = -60; // delay to allow for computer startup time

void setup() {
 Serial.begin(9600); // opens serial port, sets data rate to 9600 bps
}

void loop() {
 while (Serial.available() > 0) {
   NoSignalCounter = 0;
   incomingChar = Serial.read();
   if (incomingChar == '1') { // '1' is the character expected from the computer
     noTone(10);
   }
   else {
     tone(10, 2400); // alarm: the character sent from the computer is different from the expected character
   }
 }
 NoSignalCounter++;
 if (NoSignalCounter >= 10) { // alarm: no character was received from the computer in the last 10 seconds
   NoSignalCounter = 0;
   tone(10, 2400); //(pin,frequency)
 }
 delay(1000);
}