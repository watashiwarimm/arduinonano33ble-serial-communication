const int buttonPin = 2; // Ubah sesuai dengan pin yang sesuai
const int ledPin = 13;   // Ubah sesuai dengan pin yang sesuai

bool buttonState = false;
bool previousButtonState = false;

void setup()
{
  pinMode(buttonPin, INPUT);
  pinMode(ledPin, OUTPUT);
  Serial.begin(9600);
}

void loop()
{
  buttonState = digitalRead(buttonPin);
  
  if (buttonState != previousButtonState)
  {
    if (buttonState == LOW)
    {
      digitalWrite(ledPin, HIGH);
      Serial.println("Button Pressed"); // Mengirim pesan "Button Pressed" ke Unity
    }
    else
    {
      digitalWrite(ledPin, LOW);
      Serial.println("Button Released"); // Mengirim pesan "Button Released" ke Unity
    }
    previousButtonState = buttonState;
  }
  
  // Jeda untuk menghindari pembacaan tombol yang berulang-ulang
  delay(100);
}