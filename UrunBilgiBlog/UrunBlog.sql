CREATE DATABASE UrunBilgiBlog_Db
GO
USE UrunBilgiBlog_Db
GO
CREATE TABLE YoneticiTurler
(
ID int IDENTITY (1,1),
Isim nvarchar (75)Not NULL
CONSTRAINT Pk_YoneticiTur  PRIMARY KEY (ID) 
)
GO
CREATE TABLE Yoneticiler
(
ID int IDENTITY (1,1),
YoneticiTurID int,
Isim nvarchar(75),
Soyad nvarchar(75),
Email nvarchar(100),
Sifre nvarchar(20),
Durum bit,
CONSTRAINT Pk_Yonetici PRIMARY KEY (ID),
CONSTRAINT fk_YoneticiYoneticiTur FOREIGN  KEY(YoneticiTurID) REFERENCES YoneticiTurler(ID)
)
GO
CREATE TABLE Uyeler
(
ID int IDENTITY (1,1),
Isim nvarchar (75) not null,
Soyad nvarchar (75) not null,
KullaniciAdý nvarchar(75) not null,
Email nvarchar (75) not null,
Sifre nvarchar (75) not null,
UyelikTarihi datetime,
Durum bit,
CONSTRAINT Pk_Uye PRIMARY KEY (ID)
)

GO
CREATE TABLE Kategoriler
(
ID int IDENTITY (1,1),
Isim nvarchar(75),
CONSTRAINT Pk_Kategori PRIMARY KEY (ID)
)
GO
CREATE TABLE Urunler
(
ID int IDENTITY (10000,1),
KategoriID int ,
YazarID int ,
Isim nvarchar(75),
Marka nvarchar(75),
Fiyat nvarchar(max),
Icerik nvarchar (max),
KapakResim nvarchar(75),
GoruntulenmeSayýsý int ,
EklemeTarihi datetime,
Durum bit,
CONSTRAINT Fk_Urun PRIMARY KEY(ID),
CONSTRAINT Fk_UrunKategori FOREIGN KEY (KategoriID) REFERENCES Kategoriler (ID),
CONSTRAINT Fk_MakaleYazar FOREIGN KEY (YazarID) REFERENCES Yoneticiler(ID),
)
GO
CREATE TABLE Yorumlar
(
ID int IDENTITY (1,1),
UyeID int ,
UrunID int ,
Icerik nvarchar(500),
YorumTarihi datetime,
OnayDurum bit,
CONSTRAINT Pk_Yorum PRIMARY KEY (ID),
CONSTRAINT Fk_YorumUrun FOREIGN KEY (UrunID) REFERENCES Urunler (ID),
CONSTRAINT Fk_YorumUye FOREIGN KEY (UyeID) REFERENCES Uyeler(ID),

)
INSERT INTO YoneticiTurler(Isim) VALUES('Admin')
INSERT INTO YoneticiTurler(Isim) VALUES('Moderatör')
INSERT INTO Yoneticiler(YoneticiTurID, Isim, Soyad, Email,Sifre,Durum)
VALUES(1, 'Jhon','Doe','jhondoe@gmail.com','123',1)