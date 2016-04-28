

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";



CREATE DATABASE IF NOT EXISTS `sr3` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `sr3`;



CREATE TABLE IF NOT EXISTS `accounts` (
  `id` bigint(255) NOT NULL AUTO_INCREMENT,
  `uuid` varchar(128) NOT NULL,
  `password` varchar(256) NOT NULL,
  `name` varchar(64) NOT NULL DEFAULT 'DEFAULT',
  `rank` int(1) NOT NULL DEFAULT '0',
  `namechosen` tinyint(1) NOT NULL DEFAULT '0',
  `verified` tinyint(1) NOT NULL DEFAULT '1',
  `guild` int(11) NOT NULL,
  `guildRank` int(11) NOT NULL,
  `guildFame` int(11) NOT NULL DEFAULT '0',
  `lastip` varchar(128) NOT NULL DEFAULT '',
  `vaultCount` int(11) NOT NULL DEFAULT '12',
  `maxCharSlot` int(11) NOT NULL DEFAULT '6',
  `regTime` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `guest` tinyint(1) NOT NULL DEFAULT '0',
  `banned` tinyint(1) NOT NULL DEFAULT '0',
  `locked` varchar(512) NOT NULL,
  `ignored` varchar(512) NOT NULL,
  `isAgeVerified` tinyint(1) NOT NULL DEFAULT '0',
  `petYardType` int(11) NOT NULL DEFAULT '4',
  `ownedSkins` varchar(2048) NOT NULL DEFAULT '834, 855, 835, 836, 848, 849, 852, 853, 854, 845, 846, 847, 912, 905, 913, 914, 900, 883, 902, 856, 851, 903, 850, 904, 915, 916, 901, 899, 872, 884, 898, 917, 8968, 885, 8969, 888, 8964, 8965, 8966, 8855, 8977, 8979, 8967, 9012, 9013, 9028, 9029, 9014, 9026, 9030, 9031, 9027, 29790, 29791, 29799, 29800, 29801, 29816, 29817, 29818, 9032, 29770, 29771, 29789, 29809, 8976, 29808, 29813, 29811, 29814, 29815, 29810, 837, 838, 839, 840, 841, 842, 843, 844, 1026, 8614, 29788, 29787, 1025, 9472, 9473, 29786, 9216, 9217, 9218, 9219',
  `authToken` varchar(128) NOT NULL DEFAULT '',
  `acceptedNewTos` tinyint(1) NOT NULL DEFAULT '1',
  `lastSeen` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `accountInUse` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`,`uuid`,`guild`,`lastip`,`banned`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;




CREATE TABLE IF NOT EXISTS `arenalb` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `wave` int(11) NOT NULL,
  `accid` int(11) NOT NULL,
  `charid` int(11) NOT NULL,
  `petid` int(11) DEFAULT NULL,
  `time` varchar(256) NOT NULL,
  `date` datetime NOT NULL,
  PRIMARY KEY (`id`,`wave`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;


CREATE TABLE IF NOT EXISTS `backpacks` (
  `accId` int(11) NOT NULL,
  `charId` int(11) NOT NULL,
  `items` varchar(128) NOT NULL DEFAULT '-1, -1, -1, -1, -1, -1, -1, -1',
  PRIMARY KEY (`accId`,`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;


CREATE TABLE IF NOT EXISTS `boards` (
  `guildId` int(11) NOT NULL,
  `text` varchar(1024) NOT NULL,
  PRIMARY KEY (`guildId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;



CREATE TABLE IF NOT EXISTS `characters` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `accId` int(11) NOT NULL,
  `charId` int(11) NOT NULL,
  `charType` int(11) NOT NULL DEFAULT '782',
  `level` int(11) NOT NULL DEFAULT '1',
  `exp` int(11) NOT NULL DEFAULT '0',
  `fame` int(11) NOT NULL DEFAULT '0',
  `items` varchar(128) NOT NULL DEFAULT '-1, -1, -1, -1',
  `hpPotions` int(11) NOT NULL DEFAULT '0',
  `mpPotions` int(11) NOT NULL DEFAULT '0',
  `hp` int(11) NOT NULL DEFAULT '1',
  `mp` int(11) NOT NULL DEFAULT '1',
  `stats` varchar(128) NOT NULL DEFAULT '1, 1, 1, 1, 1, 1, 1, 1',
  `dead` tinyint(1) NOT NULL DEFAULT '0',
  `tex1` int(11) NOT NULL DEFAULT '0',
  `tex2` int(11) NOT NULL DEFAULT '0',
  `pet` int(11) NOT NULL DEFAULT '-1',
  `petId` int(11) NOT NULL DEFAULT '-1',
  `hasBackpack` int(11) NOT NULL DEFAULT '0',
  `skin` int(11) NOT NULL DEFAULT '0',
  `xpBoosterTime` int(11) NOT NULL DEFAULT '0',
  `ldTimer` int(11) NOT NULL DEFAULT '0',
  `ltTimer` int(11) NOT NULL DEFAULT '0',
  `fameStats` varchar(512) NOT NULL,
  `createTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `deathTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `totalFame` int(11) NOT NULL DEFAULT '0',
  `lastSeen` datetime NOT NULL,
  `lastLocation` varchar(128) NOT NULL,
  PRIMARY KEY (`id`,`accId`,`dead`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;


CREATE TABLE IF NOT EXISTS `classstats` (
  `accId` int(11) NOT NULL,
  `objType` int(11) NOT NULL,
  `bestLv` int(11) NOT NULL DEFAULT '1',
  `bestFame` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`accId`,`objType`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;


CREATE TABLE IF NOT EXISTS `globalnews` (
  `slot` int(11) NOT NULL,
  `linkType` int(11) NOT NULL,
  `title` varchar(65) NOT NULL,
  `image` text NOT NULL,
  `priority` int(11) NOT NULL,
  `linkDetail` text NOT NULL,
  `platform` varchar(128) NOT NULL DEFAULT 'kabam.com,kongregate,steam,rotmg',
  `startTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `endTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`slot`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


CREATE TABLE IF NOT EXISTS `death` (
  `accId` int(11) NOT NULL,
  `chrId` int(11) NOT NULL,
  `name` varchar(64) NOT NULL DEFAULT 'DEFAULT',
  `charType` int(11) NOT NULL DEFAULT '782',
  `tex1` int(11) NOT NULL DEFAULT '0',
  `tex2` int(11) NOT NULL DEFAULT '0',
  `skin` int(11) NOT NULL DEFAULT '0',
  `items` varchar(128) NOT NULL DEFAULT '-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1',
  `fame` int(11) NOT NULL DEFAULT '0',
  `exp` int(11) NOT NULL,
  `fameStats` varchar(256) NOT NULL,
  `totalFame` int(11) NOT NULL DEFAULT '0',
  `firstBorn` tinyint(1) NOT NULL,
  `killer` varchar(128) NOT NULL,
  `time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`accId`,`chrId`,`time`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;




CREATE TABLE IF NOT EXISTS `guilds` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(128) NOT NULL DEFAULT 'DEFAULT_GUILD',
  `members` varchar(128) NOT NULL,
  `guildFame` int(11) NOT NULL,
  `totalGuildFame` int(11) NOT NULL,
  `level` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`,`members`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;




CREATE TABLE IF NOT EXISTS `news` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `icon` varchar(16) NOT NULL DEFAULT 'info',
  `title` varchar(128) NOT NULL DEFAULT 'Default news title',
  `text` varchar(128) NOT NULL DEFAULT 'Default news text',
  `link` varchar(256) NOT NULL DEFAULT 'http://mmoe.net/',
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`,`text`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;



CREATE TABLE IF NOT EXISTS `pets` (
  `accId` int(11) NOT NULL,
  `petId` int(11) NOT NULL AUTO_INCREMENT,
  `objType` smallint(5) NOT NULL,
  `skinName` varchar(128) NOT NULL,
  `skin` int(11) NOT NULL,
  `family` int(11) NOT NULL,
  `rarity` int(11) NOT NULL,
  `maxLevel` int(11) NOT NULL DEFAULT '30',
  `abilities` varchar(128) NOT NULL,
  `levels` varchar(128) NOT NULL,
  `xp` varchar(128) NOT NULL DEFAULT '0, 0, 0',
  PRIMARY KEY (`accId`,`petId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;


CREATE TABLE IF NOT EXISTS `stats` (
  `accId` int(11) NOT NULL,
  `fame` int(11) NOT NULL,
  `totalFame` int(11) NOT NULL,
  `credits` int(11) NOT NULL,
  `totalCredits` int(11) NOT NULL,
  `fortuneTokens` int(11) NOT NULL,
  `totalFortuneTokens` int(11) NOT NULL,
  PRIMARY KEY (`accId`,`fame`,`totalFame`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;



CREATE TABLE IF NOT EXISTS `unlockedclasses` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `accId` int(11) NOT NULL,
  `class` varchar(128) NOT NULL,
  `available` varchar(128) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;


CREATE TABLE IF NOT EXISTS `vaults` (
  `accId` int(11) NOT NULL,
  `chestId` int(11) NOT NULL AUTO_INCREMENT,
  `items` varchar(128) NOT NULL,
  PRIMARY KEY (`accId`,`chestId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;


