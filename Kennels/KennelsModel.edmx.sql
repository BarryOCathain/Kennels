
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/06/2016 15:39:32
-- Generated from EDMX file: C:\Users\arcan\Source\Repos\Kennels\Kennels\KennelsModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Kennels];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PricingAnimal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pricings] DROP CONSTRAINT [FK_PricingAnimal];
GO
IF OBJECT_ID(N'[dbo].[FK_AnimalNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notes] DROP CONSTRAINT [FK_AnimalNote];
GO
IF OBJECT_ID(N'[dbo].[FK_BreedDog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Animals_Dog] DROP CONSTRAINT [FK_BreedDog];
GO
IF OBJECT_ID(N'[dbo].[FK_BirdSpeciesBird]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Animals_Bird] DROP CONSTRAINT [FK_BirdSpeciesBird];
GO
IF OBJECT_ID(N'[dbo].[FK_AnimalOwner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Animals] DROP CONSTRAINT [FK_AnimalOwner];
GO
IF OBJECT_ID(N'[dbo].[FK_KennelPen]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pens] DROP CONSTRAINT [FK_KennelPen];
GO
IF OBJECT_ID(N'[dbo].[FK_AnimalKennel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kennels] DROP CONSTRAINT [FK_AnimalKennel];
GO
IF OBJECT_ID(N'[dbo].[FK_OwnerBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_OwnerBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentTypePayment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Payments] DROP CONSTRAINT [FK_PaymentTypePayment];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingPayment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Payments] DROP CONSTRAINT [FK_BookingPayment];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingDiscount_Booking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingDiscount] DROP CONSTRAINT [FK_BookingDiscount_Booking];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingDiscount_Discount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingDiscount] DROP CONSTRAINT [FK_BookingDiscount_Discount];
GO
IF OBJECT_ID(N'[dbo].[FK_Dog_inherits_Animal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Animals_Dog] DROP CONSTRAINT [FK_Dog_inherits_Animal];
GO
IF OBJECT_ID(N'[dbo].[FK_Bird_inherits_Animal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Animals_Bird] DROP CONSTRAINT [FK_Bird_inherits_Animal];
GO
IF OBJECT_ID(N'[dbo].[FK_Cat_inherits_Animal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Animals_Cat] DROP CONSTRAINT [FK_Cat_inherits_Animal];
GO
IF OBJECT_ID(N'[dbo].[FK_Hamster_inherits_Animal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Animals_Hamster] DROP CONSTRAINT [FK_Hamster_inherits_Animal];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Animals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Animals];
GO
IF OBJECT_ID(N'[dbo].[Pricings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pricings];
GO
IF OBJECT_ID(N'[dbo].[Pens]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pens];
GO
IF OBJECT_ID(N'[dbo].[Kennels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kennels];
GO
IF OBJECT_ID(N'[dbo].[Notes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notes];
GO
IF OBJECT_ID(N'[dbo].[Bookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bookings];
GO
IF OBJECT_ID(N'[dbo].[Owners]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Owners];
GO
IF OBJECT_ID(N'[dbo].[DogBreeds]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DogBreeds];
GO
IF OBJECT_ID(N'[dbo].[BirdSpecies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BirdSpecies];
GO
IF OBJECT_ID(N'[dbo].[PaymentTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentTypes];
GO
IF OBJECT_ID(N'[dbo].[Payments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Payments];
GO
IF OBJECT_ID(N'[dbo].[Discounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Discounts];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Animals_Dog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Animals_Dog];
GO
IF OBJECT_ID(N'[dbo].[Animals_Bird]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Animals_Bird];
GO
IF OBJECT_ID(N'[dbo].[Animals_Cat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Animals_Cat];
GO
IF OBJECT_ID(N'[dbo].[Animals_Hamster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Animals_Hamster];
GO
IF OBJECT_ID(N'[dbo].[BookingDiscount]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookingDiscount];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Animals'
CREATE TABLE [dbo].[Animals] (
    [AnimalID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Age] int  NOT NULL,
    [IsObsolete] bit  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [IsMale] bit  NOT NULL,
    [Owner_OwnerID] int  NOT NULL
);
GO

-- Creating table 'Pricings'
CREATE TABLE [dbo].[Pricings] (
    [PricingID] int IDENTITY(1,1) NOT NULL,
    [CostPerNight] float  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [IsObsolete] bit  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [Animal_AnimalID] int  NOT NULL
);
GO

-- Creating table 'Pens'
CREATE TABLE [dbo].[Pens] (
    [PenID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [IsObsolete] bit  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [Capacity] int  NOT NULL,
    [Kennel_KennelID] int  NOT NULL
);
GO

-- Creating table 'Kennels'
CREATE TABLE [dbo].[Kennels] (
    [KennelID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [IsObsolete] bit  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [Animal_AnimalID] int  NOT NULL
);
GO

-- Creating table 'Notes'
CREATE TABLE [dbo].[Notes] (
    [NoteID] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [IsObsolete] bit  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [Animal_AnimalID] int  NOT NULL
);
GO

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [BookingID] int IDENTITY(1,1) NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [Cost] float  NOT NULL,
    [IsObsolete] bit  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [Owner_OwnerID] int  NOT NULL
);
GO

-- Creating table 'Owners'
CREATE TABLE [dbo].[Owners] (
    [OwnerID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [PropertyNameNumber] nvarchar(max)  NOT NULL,
    [Address1] nvarchar(max)  NOT NULL,
    [Address2] nvarchar(max)  NOT NULL,
    [Address3] nvarchar(max)  NOT NULL,
    [Postcode] nvarchar(max)  NOT NULL,
    [Phone1] nvarchar(max)  NOT NULL,
    [Phone2] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [IsObsolete] bit  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL
);
GO

-- Creating table 'DogBreeds'
CREATE TABLE [dbo].[DogBreeds] (
    [DogBreedID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [IsObsolete] bit  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL
);
GO

-- Creating table 'BirdSpecies'
CREATE TABLE [dbo].[BirdSpecies] (
    [BirdSpeciesID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [IsObsolete] bit  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL
);
GO

-- Creating table 'PaymentTypes'
CREATE TABLE [dbo].[PaymentTypes] (
    [PaymentTypeID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [IsObsolete] bit  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL
);
GO

-- Creating table 'Payments'
CREATE TABLE [dbo].[Payments] (
    [PaymentID] int IDENTITY(1,1) NOT NULL,
    [Amount] float  NOT NULL,
    [IsObsolete] bit  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [PaymentType_PaymentTypeID] int  NOT NULL,
    [Booking_BookingID] int  NOT NULL
);
GO

-- Creating table 'Discounts'
CREATE TABLE [dbo].[Discounts] (
    [DiscountID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Multiplier] float  NOT NULL,
    [Value] float  NOT NULL,
    [IsObsolete] bit  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [IsObsolete] bit  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [IsAdmin] bit  NOT NULL
);
GO

-- Creating table 'Animals_Dog'
CREATE TABLE [dbo].[Animals_Dog] (
    [AnimalID] int  NOT NULL,
    [DogBreed_DogBreedID] int  NOT NULL
);
GO

-- Creating table 'Animals_Bird'
CREATE TABLE [dbo].[Animals_Bird] (
    [AnimalID] int  NOT NULL,
    [BirdSpecy_BirdSpeciesID] int  NOT NULL
);
GO

-- Creating table 'Animals_Cat'
CREATE TABLE [dbo].[Animals_Cat] (
    [AnimalID] int  NOT NULL
);
GO

-- Creating table 'Animals_Hamster'
CREATE TABLE [dbo].[Animals_Hamster] (
    [AnimalID] int  NOT NULL
);
GO

-- Creating table 'BookingDiscount'
CREATE TABLE [dbo].[BookingDiscount] (
    [Bookings_BookingID] int  NOT NULL,
    [Discounts_DiscountID] int  NOT NULL
);
GO

-- Creating table 'AnimalPen'
CREATE TABLE [dbo].[AnimalPen] (
    [Animals_AnimalID] int  NOT NULL,
    [Pens_PenID] int  NOT NULL
);
GO

-- Creating table 'BookingPen'
CREATE TABLE [dbo].[BookingPen] (
    [Bookings_BookingID] int  NOT NULL,
    [Pens_PenID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AnimalID] in table 'Animals'
ALTER TABLE [dbo].[Animals]
ADD CONSTRAINT [PK_Animals]
    PRIMARY KEY CLUSTERED ([AnimalID] ASC);
GO

-- Creating primary key on [PricingID] in table 'Pricings'
ALTER TABLE [dbo].[Pricings]
ADD CONSTRAINT [PK_Pricings]
    PRIMARY KEY CLUSTERED ([PricingID] ASC);
GO

-- Creating primary key on [PenID] in table 'Pens'
ALTER TABLE [dbo].[Pens]
ADD CONSTRAINT [PK_Pens]
    PRIMARY KEY CLUSTERED ([PenID] ASC);
GO

-- Creating primary key on [KennelID] in table 'Kennels'
ALTER TABLE [dbo].[Kennels]
ADD CONSTRAINT [PK_Kennels]
    PRIMARY KEY CLUSTERED ([KennelID] ASC);
GO

-- Creating primary key on [NoteID] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [PK_Notes]
    PRIMARY KEY CLUSTERED ([NoteID] ASC);
GO

-- Creating primary key on [BookingID] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([BookingID] ASC);
GO

-- Creating primary key on [OwnerID] in table 'Owners'
ALTER TABLE [dbo].[Owners]
ADD CONSTRAINT [PK_Owners]
    PRIMARY KEY CLUSTERED ([OwnerID] ASC);
GO

-- Creating primary key on [DogBreedID] in table 'DogBreeds'
ALTER TABLE [dbo].[DogBreeds]
ADD CONSTRAINT [PK_DogBreeds]
    PRIMARY KEY CLUSTERED ([DogBreedID] ASC);
GO

-- Creating primary key on [BirdSpeciesID] in table 'BirdSpecies'
ALTER TABLE [dbo].[BirdSpecies]
ADD CONSTRAINT [PK_BirdSpecies]
    PRIMARY KEY CLUSTERED ([BirdSpeciesID] ASC);
GO

-- Creating primary key on [PaymentTypeID] in table 'PaymentTypes'
ALTER TABLE [dbo].[PaymentTypes]
ADD CONSTRAINT [PK_PaymentTypes]
    PRIMARY KEY CLUSTERED ([PaymentTypeID] ASC);
GO

-- Creating primary key on [PaymentID] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [PK_Payments]
    PRIMARY KEY CLUSTERED ([PaymentID] ASC);
GO

-- Creating primary key on [DiscountID] in table 'Discounts'
ALTER TABLE [dbo].[Discounts]
ADD CONSTRAINT [PK_Discounts]
    PRIMARY KEY CLUSTERED ([DiscountID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [AnimalID] in table 'Animals_Dog'
ALTER TABLE [dbo].[Animals_Dog]
ADD CONSTRAINT [PK_Animals_Dog]
    PRIMARY KEY CLUSTERED ([AnimalID] ASC);
GO

-- Creating primary key on [AnimalID] in table 'Animals_Bird'
ALTER TABLE [dbo].[Animals_Bird]
ADD CONSTRAINT [PK_Animals_Bird]
    PRIMARY KEY CLUSTERED ([AnimalID] ASC);
GO

-- Creating primary key on [AnimalID] in table 'Animals_Cat'
ALTER TABLE [dbo].[Animals_Cat]
ADD CONSTRAINT [PK_Animals_Cat]
    PRIMARY KEY CLUSTERED ([AnimalID] ASC);
GO

-- Creating primary key on [AnimalID] in table 'Animals_Hamster'
ALTER TABLE [dbo].[Animals_Hamster]
ADD CONSTRAINT [PK_Animals_Hamster]
    PRIMARY KEY CLUSTERED ([AnimalID] ASC);
GO

-- Creating primary key on [Bookings_BookingID], [Discounts_DiscountID] in table 'BookingDiscount'
ALTER TABLE [dbo].[BookingDiscount]
ADD CONSTRAINT [PK_BookingDiscount]
    PRIMARY KEY CLUSTERED ([Bookings_BookingID], [Discounts_DiscountID] ASC);
GO

-- Creating primary key on [Animals_AnimalID], [Pens_PenID] in table 'AnimalPen'
ALTER TABLE [dbo].[AnimalPen]
ADD CONSTRAINT [PK_AnimalPen]
    PRIMARY KEY CLUSTERED ([Animals_AnimalID], [Pens_PenID] ASC);
GO

-- Creating primary key on [Bookings_BookingID], [Pens_PenID] in table 'BookingPen'
ALTER TABLE [dbo].[BookingPen]
ADD CONSTRAINT [PK_BookingPen]
    PRIMARY KEY CLUSTERED ([Bookings_BookingID], [Pens_PenID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Animal_AnimalID] in table 'Pricings'
ALTER TABLE [dbo].[Pricings]
ADD CONSTRAINT [FK_PricingAnimal]
    FOREIGN KEY ([Animal_AnimalID])
    REFERENCES [dbo].[Animals]
        ([AnimalID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PricingAnimal'
CREATE INDEX [IX_FK_PricingAnimal]
ON [dbo].[Pricings]
    ([Animal_AnimalID]);
GO

-- Creating foreign key on [Animal_AnimalID] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [FK_AnimalNote]
    FOREIGN KEY ([Animal_AnimalID])
    REFERENCES [dbo].[Animals]
        ([AnimalID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AnimalNote'
CREATE INDEX [IX_FK_AnimalNote]
ON [dbo].[Notes]
    ([Animal_AnimalID]);
GO

-- Creating foreign key on [DogBreed_DogBreedID] in table 'Animals_Dog'
ALTER TABLE [dbo].[Animals_Dog]
ADD CONSTRAINT [FK_BreedDog]
    FOREIGN KEY ([DogBreed_DogBreedID])
    REFERENCES [dbo].[DogBreeds]
        ([DogBreedID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BreedDog'
CREATE INDEX [IX_FK_BreedDog]
ON [dbo].[Animals_Dog]
    ([DogBreed_DogBreedID]);
GO

-- Creating foreign key on [BirdSpecy_BirdSpeciesID] in table 'Animals_Bird'
ALTER TABLE [dbo].[Animals_Bird]
ADD CONSTRAINT [FK_BirdSpeciesBird]
    FOREIGN KEY ([BirdSpecy_BirdSpeciesID])
    REFERENCES [dbo].[BirdSpecies]
        ([BirdSpeciesID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BirdSpeciesBird'
CREATE INDEX [IX_FK_BirdSpeciesBird]
ON [dbo].[Animals_Bird]
    ([BirdSpecy_BirdSpeciesID]);
GO

-- Creating foreign key on [Owner_OwnerID] in table 'Animals'
ALTER TABLE [dbo].[Animals]
ADD CONSTRAINT [FK_AnimalOwner]
    FOREIGN KEY ([Owner_OwnerID])
    REFERENCES [dbo].[Owners]
        ([OwnerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AnimalOwner'
CREATE INDEX [IX_FK_AnimalOwner]
ON [dbo].[Animals]
    ([Owner_OwnerID]);
GO

-- Creating foreign key on [Kennel_KennelID] in table 'Pens'
ALTER TABLE [dbo].[Pens]
ADD CONSTRAINT [FK_KennelPen]
    FOREIGN KEY ([Kennel_KennelID])
    REFERENCES [dbo].[Kennels]
        ([KennelID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KennelPen'
CREATE INDEX [IX_FK_KennelPen]
ON [dbo].[Pens]
    ([Kennel_KennelID]);
GO

-- Creating foreign key on [Animal_AnimalID] in table 'Kennels'
ALTER TABLE [dbo].[Kennels]
ADD CONSTRAINT [FK_AnimalKennel]
    FOREIGN KEY ([Animal_AnimalID])
    REFERENCES [dbo].[Animals]
        ([AnimalID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AnimalKennel'
CREATE INDEX [IX_FK_AnimalKennel]
ON [dbo].[Kennels]
    ([Animal_AnimalID]);
GO

-- Creating foreign key on [Owner_OwnerID] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_OwnerBooking]
    FOREIGN KEY ([Owner_OwnerID])
    REFERENCES [dbo].[Owners]
        ([OwnerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OwnerBooking'
CREATE INDEX [IX_FK_OwnerBooking]
ON [dbo].[Bookings]
    ([Owner_OwnerID]);
GO

-- Creating foreign key on [PaymentType_PaymentTypeID] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [FK_PaymentTypePayment]
    FOREIGN KEY ([PaymentType_PaymentTypeID])
    REFERENCES [dbo].[PaymentTypes]
        ([PaymentTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentTypePayment'
CREATE INDEX [IX_FK_PaymentTypePayment]
ON [dbo].[Payments]
    ([PaymentType_PaymentTypeID]);
GO

-- Creating foreign key on [Booking_BookingID] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [FK_BookingPayment]
    FOREIGN KEY ([Booking_BookingID])
    REFERENCES [dbo].[Bookings]
        ([BookingID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingPayment'
CREATE INDEX [IX_FK_BookingPayment]
ON [dbo].[Payments]
    ([Booking_BookingID]);
GO

-- Creating foreign key on [Bookings_BookingID] in table 'BookingDiscount'
ALTER TABLE [dbo].[BookingDiscount]
ADD CONSTRAINT [FK_BookingDiscount_Booking]
    FOREIGN KEY ([Bookings_BookingID])
    REFERENCES [dbo].[Bookings]
        ([BookingID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Discounts_DiscountID] in table 'BookingDiscount'
ALTER TABLE [dbo].[BookingDiscount]
ADD CONSTRAINT [FK_BookingDiscount_Discount]
    FOREIGN KEY ([Discounts_DiscountID])
    REFERENCES [dbo].[Discounts]
        ([DiscountID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingDiscount_Discount'
CREATE INDEX [IX_FK_BookingDiscount_Discount]
ON [dbo].[BookingDiscount]
    ([Discounts_DiscountID]);
GO

-- Creating foreign key on [Animals_AnimalID] in table 'AnimalPen'
ALTER TABLE [dbo].[AnimalPen]
ADD CONSTRAINT [FK_AnimalPen_Animal]
    FOREIGN KEY ([Animals_AnimalID])
    REFERENCES [dbo].[Animals]
        ([AnimalID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Pens_PenID] in table 'AnimalPen'
ALTER TABLE [dbo].[AnimalPen]
ADD CONSTRAINT [FK_AnimalPen_Pen]
    FOREIGN KEY ([Pens_PenID])
    REFERENCES [dbo].[Pens]
        ([PenID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AnimalPen_Pen'
CREATE INDEX [IX_FK_AnimalPen_Pen]
ON [dbo].[AnimalPen]
    ([Pens_PenID]);
GO

-- Creating foreign key on [Bookings_BookingID] in table 'BookingPen'
ALTER TABLE [dbo].[BookingPen]
ADD CONSTRAINT [FK_BookingPen_Booking]
    FOREIGN KEY ([Bookings_BookingID])
    REFERENCES [dbo].[Bookings]
        ([BookingID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Pens_PenID] in table 'BookingPen'
ALTER TABLE [dbo].[BookingPen]
ADD CONSTRAINT [FK_BookingPen_Pen]
    FOREIGN KEY ([Pens_PenID])
    REFERENCES [dbo].[Pens]
        ([PenID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingPen_Pen'
CREATE INDEX [IX_FK_BookingPen_Pen]
ON [dbo].[BookingPen]
    ([Pens_PenID]);
GO

-- Creating foreign key on [AnimalID] in table 'Animals_Dog'
ALTER TABLE [dbo].[Animals_Dog]
ADD CONSTRAINT [FK_Dog_inherits_Animal]
    FOREIGN KEY ([AnimalID])
    REFERENCES [dbo].[Animals]
        ([AnimalID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AnimalID] in table 'Animals_Bird'
ALTER TABLE [dbo].[Animals_Bird]
ADD CONSTRAINT [FK_Bird_inherits_Animal]
    FOREIGN KEY ([AnimalID])
    REFERENCES [dbo].[Animals]
        ([AnimalID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AnimalID] in table 'Animals_Cat'
ALTER TABLE [dbo].[Animals_Cat]
ADD CONSTRAINT [FK_Cat_inherits_Animal]
    FOREIGN KEY ([AnimalID])
    REFERENCES [dbo].[Animals]
        ([AnimalID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AnimalID] in table 'Animals_Hamster'
ALTER TABLE [dbo].[Animals_Hamster]
ADD CONSTRAINT [FK_Hamster_inherits_Animal]
    FOREIGN KEY ([AnimalID])
    REFERENCES [dbo].[Animals]
        ([AnimalID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------