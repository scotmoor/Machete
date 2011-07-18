/****** Script for SelectTopNRows command from SSMS  ******/
delete from machete.dbo.Employers
delete from machete.dbo.WorkOrders
delete from machete.dbo.WorkAssignments
delete from machete.dbo.WorkerRequests
delete from machete.dbo.workersignins
delete from machete.dbo.workers
delete from machete.dbo.Persons
delete from machete.dbo.images
go
set IDENTITY_INSERT machete.dbo.Employers ON
insert into machete.dbo.Employers ([ID],[active],[name],[address1],[address2],[city],[state],[phone],[cellphone],[zipcode],[email],[referredby],[referredbyOther],[blogparticipate],[datecreated],[dateupdated],[Createdby],[Updatedby])
SELECT [ID],[active],[name],[address1],[address2],[city],[state],[phone],[cellphone],[zipcode],[email],[referredby],[referredbyOther],'0',[datecreated],[dateupdated],[Createdby],[Updatedby]
  FROM [macheteStageProd].[dbo].[Employers]
go
set IDENTITY_INSERT machete.dbo.Employers OFF
go
/**************************************************/
set IDENTITY_INSERT machete.dbo.WorkOrders ON
insert [machete].[dbo].[WorkOrders] ([ID],[EmployerID],[paperOrderNum],[contactName],[status],[workSiteAddress1],[workSiteAddress2],[city],[state],[phone],[zipcode],[typeOfWorkID],[englishRequired],[englishRequiredNote],[lunchSupplied],[permanentPlacement],[transportMethodID],[transportFee],[transportFeeExtra],[description],[dateTimeofWork],[timeFlexible],[datecreated],[dateupdated],[Createdby],[Updatedby])
SELECT [ID],[EmployerID],null,[contactName],[status],[workSiteAddress1],[workSiteAddress2],[city],[state],[phone],[zipcode],[typeOfWorkID],[englishRequired],[englishRequiredNote],[lunchSupplied],[permanentPlacement],[transportMethodID],[transportFee],[transportFeeExtra],[description],[dateTimeofWork],[timeFlexible],[datecreated],[dateupdated],[Createdby],[Updatedby]
  FROM [macheteStageProd].[dbo].[WorkOrders]
GO
set IDENTITY_INSERT machete.dbo.WorkOrders OFF
GO
/**************************************************/
set IDENTITY_INSERT machete.dbo.WorkAssignments ON
insert [machete].[dbo].[WorkAssignments] ([ID],[workerAssignedID],[workOrderID],[workerSigninID],[active],[pseudoID],[description],[englishLevelID],[skillID],[hourlyWage],[hours],[days],[qualityOfWork],[followDirections],[attitude],[reliability],[transportProgram],[comments],[datecreated],[dateupdated],[Createdby],[Updatedby],[WorkerID])
SELECT [ID],[workerAssignedID],[workOrderID],[workerSigninID],[active],null,[description],[englishLevelID],[skillID],[hourlyWage],[hours],[days],[qualityOfWork],[followDirections],[attitude],[reliability],[transportProgram],[comments],[datecreated],[dateupdated],[Createdby],[Updatedby],[WorkerID]
  FROM [macheteStageProd].[dbo].[WorkAssignments]
GO
set IDENTITY_INSERT machete.dbo.WorkAssignments OFF
go
/**************************************************/
set IDENTITY_INSERT machete.dbo.Persons ON
insert machete.dbo.persons ([ID],[active],[firstname1],[firstname2],[lastname1],[lastname2],[address1],[address2],[city],[state],[zipcode],[phone],[gender],[genderother],[datecreated],[dateupdated],[Createdby],[Updatedby])
SELECT [ID],[active],[firstname1],[firstname2],[lastname1],[lastname2],[address1],[address2],[city],[state],[zipcode],[phone],[gender],[genderother],[datecreated],[dateupdated],[Createdby],[Updatedby]
  FROM [macheteStageProd].[dbo].[Persons]
GO
set IDENTITY_INSERT machete.dbo.Persons OFF
go
/**************************************************/
insert machete.dbo.workers ([ID],[typeOfWorkID],[dateOfMembership],[dateOfBirth],[active],[RaceID],[raceother],[height],[weight],[englishlevelID],[recentarrival],[dateinUSA],[dateinseattle],[disabled],[disabilitydesc],[maritalstatus],[livewithchildren],[numofchildren],[incomeID],[livealone],[emcontUSAname],[emcontUSArelation],[emcontUSAphone],[dwccardnum],[neighborhoodID],[immigrantrefugee],[countryoforiginID],[emcontoriginname],[emcontoriginrelation],[emcontoriginphone],[memberexpirationdate],[driverslicense],[licenseexpirationdate],[carinsurance],[insuranceexpiration],[ImageID],[skill1],[skill2],[skill3],[datecreated],[dateupdated],[Createdby],[Updatedby])
SELECT w.[ID],case p.gender when 38 then 20 when 39 then 21 end,[dateOfMembership],[dateOfBirth],w.[active],[RaceID],[raceother],[height],[weight],[englishlevelID],[recentarrival],[dateinUSA],[dateinseattle],[disabled],[disabilitydesc],[maritalstatus],[livewithchildren],[numofchildren],[incomeID],[livealone],[emcontUSAname],[emcontUSArelation],[emcontUSAphone],[dwccardnum],[neighborhoodID],[immigrantrefugee],[countryoforiginID],[emcontoriginname],[emcontoriginrelation],[emcontoriginphone],[memberexpirationdate],[driverslicense],[licenseexpirationdate],[carinsurance],[insuranceexpiration],[ImageID],[skill1],[skill2],[skill3],w.[datecreated],w.[dateupdated],w.[Createdby],w.[Updatedby]
  FROM [macheteStageProd].[dbo].[Workers] w join machetestageprod.dbo.persons p on p.ID = w.ID
GO
/**************************************************/
set IDENTITY_INSERT machete.dbo.WorkerSignins ON
insert machete.dbo.workersignins ([ID],[dwccardnum],[WorkerID],[WorkAssignmentID],[dateforsignin],[datecreated],[dateupdated],[Createdby],[Updatedby])
SELECT [ID],[dwccardnum],[WorkerID],[WorkAssignmentID],[dateforsignin],[datecreated],[dateupdated],[Createdby],[Updatedby]
  FROM [macheteStageProd].[dbo].[WorkerSignins]
GO
set IDENTITY_INSERT machete.dbo.WorkerSignins OFF
go
/**************************************************/
set IDENTITY_INSERT machete.dbo.Images ON
insert machete.dbo.images ([ID],[ImageData],[ImageMimeType],[filename],[Thumbnail],[ThumbnailMimeType],[parenttable],[recordkey],[datecreated],[dateupdated],[Createdby],[Updatedby])
SELECT [ID],[ImageData],[ImageMimeType],[filename],[Thumbnail],[ThumbnailMimeType],[parenttable],[recordkey],[datecreated],[dateupdated],[Createdby],[Updatedby]
  FROM [machetestageprod].[dbo].[Images]
GO
set IDENTITY_INSERT machete.dbo.Images OFF
go
/**************************************************/
set IDENTITY_INSERT machete.dbo.workerrequests ON
insert machete.dbo.workerrequests ([ID],[WorkOrderID],[WorkerID],[datecreated],[dateupdated],[Createdby],[Updatedby])
SELECT [ID],[WorkOrderID],[WorkerID],[datecreated],[dateupdated],[Createdby],[Updatedby]
  FROM [macheteStageProd].[dbo].[WorkerRequests]
GO
set IDENTITY_INSERT machete.dbo.workerrequests OFF
go