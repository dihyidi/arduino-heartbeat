#include <LiquidCrystal.h>

#define BUZZER 6
#define SENSOR 4
#define BUTTON 2
#define BEEP_DELAY 200

LiquidCrystal lcd(13,12,11,10,9,8);

bool isStart;
bool isCheck;
double seconds;
int count;

void startCount();
void beep();
void countHb(double seconds);
void sendData(int count);
void showResult(int count);
void reset();

ISR(TIMER1_COMPA_vect)
{
  if (isStart)
    seconds += 1;
}

ISR(TIMER2_COMPA_vect)
{
  if(isStart)
    countHb(seconds);
}

void countHb(double seconds) {
  if(seconds >= 15) {
    int result = count * 4;
    reset();
    showResult(result);
    sendData(result);
    return;
  }
  if(digitalRead(SENSOR) && !isCheck) {
        count++;
        isCheck = true;
   }

   if(!digitalRead(SENSOR) && isCheck) {
        isCheck = false;
   }
  
  lcd.setCursor(14,0);
  lcd.print(count);
  lcd.setCursor(14,1);
  lcd.print(seconds);
}

void reset() {
    isStart = false;
    seconds = 0;
    count = 0;
    isCheck = false;
}

void showResult(int count) {
  lcd.clear();
  lcd.setCursor(0,0);
  lcd.print("HB per Min: ");
  lcd.setCursor(14,0);
  lcd.print(count);
  lcd.setCursor(0,1);
  lcd.print("Press button");
}

void sendData(int count) {
  Serial.write(count);
}

void beep() {
  digitalWrite(BUZZER, HIGH);
  delay(BEEP_DELAY);
  digitalWrite(BUZZER, LOW);
}

void setup() {
  pinMode(SENSOR, INPUT);
  pinMode(BUTTON, INPUT_PULLUP);
  
  pinMode(BUZZER, OUTPUT);
  digitalWrite(BUZZER, LOW);

  isCheck = false;
  isStart = false;
  seconds = 0;
  count = 0;

  noInterrupts();

  TCCR1A = 0x00;
  TCCR1B = (1 << WGM12) | (1 << CS12) | (1 << CS10); // CTC mode & Prescaler @ 2048
  TIMSK1 = (1 << OCIE1A);
  OCR1A = 0x3D08; // compare value = 1 sec (12MHz AVR)

  TCCR2A = 0x00;
  TCCR2B = (1 << WGM22) | (1 << CS22) | (1 << CS20); // CTC mode & Prescaler @ 1024
  TIMSK2 = (1 << OCIE2A);
  OCR2A = 156; // compare value for 500 Hz (12MHz AVR)

  interrupts();

  Serial.begin(9600);
//  lcd.begin(20, 4);
lcd.init(20, 4);
  lcd.clear();
  lcd.print("Press button");
}

void startCount() {
    lcd.clear();
    isStart = true;
    
    lcd.setCursor(0,0);
    lcd.print("Current HB: ");
    lcd.setCursor(0,1);
    lcd.print("Time in Sec: ");
}

void loop() {
  if(Serial.available()) {
    char inByte = Serial.read();
    if(inByte == '1' && !isStart) {
      startCount();
    }
  }
  
  if(!digitalRead(BUTTON) && !isStart){
    startCount();
  }
}
