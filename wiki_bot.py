import wikipedia
import sys


wikipedia.set_lang("tr")

def bilgi_kaydet(konu):
    try:
        ozet = wikipedia.summary(konu, sentences=2)
        with open("bilgi.txt", "w", encoding="utf-8") as f:
            f.write(ozet)
        print("Bitti") # C#'a işin bittiğini fısıldıyoruz
    except:
        with open("bilgi.txt", "w", encoding="utf-8") as f:
            f.write("Maalesef bilgi bulunamadı.")

if __name__ == "__main__":
    # Eğer C#'tan bir kelime gelirse onu ara, gelmezse varsayılan 'Torna' ara
    arama = sys.argv[1] if len(sys.argv) > 1 else "Torna"
    bilgi_kaydet(arama)