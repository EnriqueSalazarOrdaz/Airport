CREATE TABLE [dbo].[Schedule]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [FromCityID] INT NOT NULL, 
    [ToCityID] INT NOT NULL, 
    [Depart] TIME NOT NULL, 
    [Arrives] TIME NOT NULL, 
    [LayoverCityID] INT NULL, 
    [LayoverTime] TIME NULL, 
    [Price] MONEY NOT NULL, 
    [AirlineID] INT NOT NULL, 
    CONSTRAINT [FK_FromCityID] FOREIGN KEY ([FromCityID]) REFERENCES [City]([Id]),
	CONSTRAINT [FK_ToCityID] FOREIGN KEY ([ToCityID]) REFERENCES [City]([Id]),
	CONSTRAINT [FK_LayoverCityID] FOREIGN KEY ([LayoverCityID]) REFERENCES [City]([Id]),
	CONSTRAINT [FK_AirlineID] FOREIGN KEY ([AirlineID]) REFERENCES [Airline]([Id])
)
