create database SocialaDb

use SocialaDb




create table [User]
(
Id int primary key IDENTITY(1,1) NOT NULL,

UserOnlineDate nvarchar(max) NOT NULL,
Username nvarchar(max) NOT NULL,
EmailAddress nvarchar(max) NOT NULL,
[Password] nvarchar(max) NOT NULL,
ConfirmPassword nvarchar(max) NOT NULL,
UserFilepath nvarchar(max) NOT NULL default(NULL)
)




create table Post
(
Id int primary key IDENTITY (1,1) NOT NULL,

PostMessage nvarchar(max) NULL,
PostImage nvarchar(max) NULL,
PostVideo nvarchar(max) NULL,
PostDate nvarchar(max) NOT NULL,

UserId_forPost int NOT NULL,


Constraint FK_UserId_forPost Foreign key (UserId_forPost) References [User](Id) On Delete CASCADE On Update CASCADE
)

--SET IDENTITY_INSERT Post off



create table Tag
(
Id int primary key IDENTITY (1,1) NOT NULL,

TagTitle1 nvarchar(max)  NULL,
TagTitle2 nvarchar(max)  NULL,
TagTitle3 nvarchar(max)  NULL,
TagTitle4 nvarchar(max)  NULL,
TagTitle5 nvarchar(max)  NULL ,
TagTitle6 nvarchar(max)  NULL,

TagTitle7 nvarchar(max)  NULL,
TagTitle8 nvarchar(max)  NULL,
TagTitle9 nvarchar(max)  NULL,
TagTitle10 nvarchar(max)  NULL,
TagTitle11 nvarchar(max)  NULL,
TagTitle12 nvarchar(max)  NULL
)



create table PostandTag
(
Id int primary key IDENTITY (1,1) NOT NULL,

PostId_forPostandTag int  NULL,
TagId_forPostandTag int NULL,


Constraint FK_PostId_forPostandTag Foreign key (PostId_forPostandTag) References Post(Id) On Delete CASCADE On Update CASCADE,
Constraint TagId_forPostandTag Foreign key (TagId_forPostandTag) References Tag(Id) On Delete CASCADE On Update CASCADE
)

create table Reaction
(
Id int primary key IDENTITY (1,1) NOT NULL,

Reaction_1 nvarchar(max) NULL,
Reaction_2 nvarchar(max) NULL,
Reaction_3 nvarchar(max) NULL,
Reaction_4 nvarchar(max) NULL,
Reaction_5 nvarchar(max) NULL,
Reaction_6 nvarchar(max) NULL,
Reaction_7 nvarchar(max) NULL,
Reaction_8 nvarchar(max) NULL,

PostId_forReaction int NOT NULL,
UserId_forReaction int NOT NULL,


Constraint FK_PostId_forReactions Foreign key (PostId_forReaction) References Post(Id) On Delete CASCADE On Update CASCADE,
Constraint FK_UserId_forReaction Foreign key (UserId_forReaction) References [User](Id) On Delete NO ACTION On Update NO ACTION
)


create table Comment
(
Id int primary key IDENTITY (1,1) NOT NULL,

CommentMessage nvarchar(max) NOT NULL,
CommentDate nvarchar(max) NOT NULL,

PostId_forComment int NOT NULL,
UserId_forComment int NOT NULL,


Constraint FK_PostId_forComment Foreign key (PostId_forComment) References Post(Id) On Delete CASCADE On Update CASCADE,
Constraint FK_UserId_forComment Foreign key (UserId_forComment) References [User](Id) On Delete NO ACTION On Update NO ACTION,

)


create table [NotificationReceiver]
(
Id int primary key IDENTITY (1,1) NOT NULL,

NotificationMessage nvarchar(max) NOT NULL,
NotificationDate nvarchar(max) NOT NULL,

UserId_forNotificationLine_asReceiver int NOT NULL,

Constraint FK_UserId_forNotification_asReceiver Foreign key (UserId_forNotificationLine_asReceiver) References [User](Id) On Delete CASCADE On Update CASCADE,
)



create table [NotificationSender]
(
Id int primary key IDENTITY (1,1) NOT NULL,

NotificationMessage nvarchar(max) NOT NULL,
NotificationDate nvarchar(max) NOT NULL,

UserId_forNotificationLine_asSender int NOT NULL,

Constraint FK_UserId_forNotification_asSender Foreign key (UserId_forNotificationLine_asSender) References [User](Id) On Delete CASCADE On Update CASCADE,
)


create table [Notification]
(
Id int primary key IDENTITY (1,1) NOT NULL,

NotificationSenderId_forNotification int NOT NULL,
NotificationReceiverId_forNotification  int NOT NULL,

Constraint FK_NotificationSender Foreign key (NotificationSenderId_forNotification) References [NotificationSender](Id)  On Delete NO ACTION On Update NO ACTION,
Constraint FK_NotificationReceiver Foreign key (NotificationReceiverId_forNotification) References [NotificationReceiver](Id)  On Delete NO ACTION On Update NO ACTION,
)


create table [Message]
(
Id int primary key IDENTITY (1,1) NOT NULL,

MessageDate nvarchar(max) NOT NULL,
MessageText nvarchar(max) NOT NULL,

SenderUserId int NOT NULL,
ReceiverUserId int NOT NULL,


Constraint FK_SenderUserId_forFriend Foreign key (SenderUserId) References [User](Id)  On Delete NO ACTION On Update NO ACTION,
Constraint FK_ReceiverUserId_forFriend Foreign key (ReceiverUserId) References [User](Id)  On Delete NO ACTION On Update NO ACTION,
)




create table Friend
(
Id int primary key IDENTITY (1,1) NOT NULL,

FriendName nvarchar(max) NOT NULL,

UserId_forFriend int NOT NULL,

Constraint FK_UserId_forFriend Foreign key (UserId_forFriend) References [User](Id)  On Delete NO ACTION On Update NO ACTION,
)





CREATE or Alter PROCEDURE currentchat
    @receiveruserId bigint,
    @senderuserId bigint
AS
BEGIN
    SET NOCOUNT ON;


 select
                SocialaDb.dbo.[Message].MessageText,
                SocialaDb.dbo.[Message].MessageDate,
                SocialaDb.dbo.[Message].SenderUserId,
                SocialaDb.dbo.[Message].ReceiverUserId
                from SocialaDb.dbo.[Message]
                INNER JOIN SocialaDb.dbo.[User]
                ON SocialaDb.dbo.[Message].ReceiverUserId = SocialaDb.dbo.[User].Id
                where
                SocialaDb.dbo.[Message].ReceiverUserId=@receiveruserId
                and
                SocialaDb.dbo.[Message].SenderUserId=@senderuserId
END



EXECUTE  SocialaDb.dbo.currentchat 2,1


-- GetAll

sp_help 'dbo.[User]'


sp_help 'dbo.Post'

set identity_insert PostandTag off;

Delete PostandTag where Id in(    
Select s.Id From PostandTag s Inner Join PostandTag s1     
On s.PostId_forPostandTag=s1.PostId_forPostandTag And s.TagId_forPostandTag=s1.TagId_forPostandTag   
Where s.Id>s1.Id)




select 
[User].Username,
Post.PostMessage,
Post.PostDate
from Post
INNER JOIN [User]
ON Post.UserId_forPost = [User].Id


select 
[User].Username,
Post.PostMessage,
Post.PostImage,
Post.PostVideo,
Tag.TagTitle1,
Tag.TagTitle2,
Tag.TagTitle3,
Tag.TagTitle4,
Tag.TagTitle5,
Tag.TagTitle6,
Tag.TagTitle7,
Tag.TagTitle8,
Tag.TagTitle9,
Tag.TagTitle10,
Tag.TagTitle11,
Tag.TagTitle12
from PostandTag
INNER JOIN Tag
ON PostandTag.TagId_forPostandTag = Tag.Id
INNER JOIN Post
ON PostandTag.PostId_forPostandTag = Post.Id
INNER JOIN [User]
on Post.UserId_forPost= [User].Id



SELECT  COUNT(*) TOTAL_Reaction
FROM Reaction
WHERE Reaction.Reaction_1 >= 0
GROUP BY Reaction.Reaction_1


select 
Post.PostMessage,
Post.PostImage,
Post.PostVideo,
Comment.CommentMessage,
[User].Username
from SocialaDb.dbo.Comment
INNER JOIN Post
ON Comment.PostId_forComment = Post.Id
INNER JOIN [User]
ON Comment.UserId_forComment = [User].Id


select *from SocialaDb.dbo.Comment
INNER JOIN Post
ON Comment.PostId_forComment = Post.Id
INNER JOIN [User]
ON Comment.UserId_forComment = [User].Id



select DISTINCT 
SocialaDb.dbo.[Message].MessageText,
SocialaDb.dbo.[Message].MessageDate,
SocialaDb.dbo.[Message].SenderUserId,
SocialaDb.dbo.[Message].ReceiverUserId
from SocialaDb.dbo.[Message],SocialaDb.dbo.[User]
where
SocialaDb.dbo.[Message].SenderUserId=SocialaDb.dbo.[User].Id
or
SocialaDb.dbo.[Message].ReceiverUserId=SocialaDb.dbo.[User].Id
GROUP BY 
SocialaDb.dbo.[Message].MessageText,
SocialaDb.dbo.[Message].MessageDate,
SocialaDb.dbo.[Message].SenderUserId,
SocialaDb.dbo.[Message].ReceiverUserId


select
SocialaDb.dbo.[Message].MessageText,
SocialaDb.dbo.[Message].MessageDate,
SocialaDb.dbo.[Message].SenderUserId,
SocialaDb.dbo.[Message].ReceiverUserId
from SocialaDb.dbo.[Message]
INNER JOIN SocialaDb.dbo.[User]
ON SocialaDb.dbo.[Message].ReceiverUserId = SocialaDb.dbo.[User].Id
where
SocialaDb.dbo.[Message].ReceiverUserId=2
and
SocialaDb.dbo.[Message].SenderUserId=1


select Distinct
SocialaDb.dbo.[Message].MessageText,
SocialaDb.dbo.[Message].MessageDate,
SocialaDb.dbo.[Message].SenderUserId,
SocialaDb.dbo.[Message].ReceiverUserId
from SocialaDb.dbo.[Message],SocialaDb.dbo.[User]
where
SocialaDb.dbo.[Message].ReceiverUserId=2
and
SocialaDb.dbo.[Message].SenderUserId=1



select 
SocialaDb.dbo.Friend.FriendName,
SocialaDb.dbo.[User].Username
from 
SocialaDb.dbo.Friend,
SocialaDb.dbo.[User]
where
SocialaDb.dbo.Friend.UserId_forFriend=SocialaDb.dbo.[User].Id


select *from CustomUserDB.dbo.AspNetUsers;

select *from SocialaDb.dbo.[User]

select *from SocialaDb.dbo.Post

select *from SocialaDb.dbo.Tag

select *from SocialaDb.dbo.PostandTag

select *from SocialaDb.dbo.Comment

select *from SocialaDb.dbo.Reaction

select *from SocialaDb.dbo.[NotificationSender]

select *from SocialaDb.dbo.[NotificationReceiver]

select *from SocialaDb.dbo.[Notification]

select *from SocialaDb.dbo.[Message]

select *from SocialaDb.dbo.Friend








DELETE FROM CustomUserDB.dbo.AspNetUsers;

DELETE FROM SocialaDb.dbo.[User];

DELETE FROM SocialaDb.dbo.Post;
DELETE FROM SocialaDb.dbo.Tag;
DELETE FROM SocialaDb.dbo.PostandTag;
DELETE FROM SocialaDb.dbo.Comment;
DELETE FROM SocialaDb.dbo.Reaction;
DELETE FROM SocialaDb.dbo.[NotificationSender];
DELETE FROM SocialaDb.dbo.[NotificationReceiver];
DELETE FROM SocialaDb.dbo.[Notification];
DELETE FROM  SocialaDb.dbo.[Message];
DELETE FROM  SocialaDb.dbo.Friend;