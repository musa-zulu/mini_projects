using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MeetingTracker.Models
{

    public class MeetingInitializer : DropCreateDatabaseIfModelChanges<MeetingContext>
    {
        protected override void Seed(MeetingContext context)
        {
            var meetingType = new List<MeetingType>()
            {
                new MeetingType
                {
                    MeetingTypeDescription = "MANCO",
                },
                   new MeetingType
                {
                    MeetingTypeDescription = "Finance",
                },
                new MeetingType
                {
                    MeetingTypeDescription = "Project Team Leaders",
                }
            };

            foreach (var type in meetingType)
            {
                context.MeetingTypes.Add(type);
            }
            context.SaveChanges();

            var meetings = new List<Meeting>()
            {
                new Meeting
                {
                    MeetingDescription = "New Meeting one",
                    MeetingDate = DateTime.Parse("2015-01-02"),
                    StartTime = DateTime.Parse("08:21 AM"),
                    EndTime = DateTime.Parse("10:21 AM"),
                    Location = "Chillisoft Offices"
                },
                new Meeting 
                {
                    MeetingDescription = "New Meeting one",
                    MeetingDate = DateTime.Parse("2015-01-02"),
                    StartTime = DateTime.Parse("08:21 AM"),
                    EndTime = DateTime.Parse("10:21 AM"),
                    Location = "Chillisoft Offices"
                }
            };
            foreach (var m in meetings)
            {
                context.Meetings.Add(m);
            }
            context.SaveChanges();


            var meetingItems = new List<MeetingItem>()
            {
                new MeetingItem
                {
                    MeetingItemDescription = "Meeting Description",
                   
                   // DueDate = DateTime.Parse("2015-02-02"),
                    Priority = "High",
                    PercentageCompleted = "15%",
                     Duration = "One Month"
                },

                new MeetingItem
                {
                    MeetingItemDescription = "Meeting Description one",
                   // StartDate = DateTime.Parse("2015-02-02"),
                   // DueDate = DateTime.Parse("2015-03-02"),
                   
                    Priority = "High",
                    PercentageCompleted = "25%",
                    Duration = "One Month"
                }
            };

            foreach (var meetingItem in meetingItems)
            {
                context.MeetingItems.Add(meetingItem);
            }
            context.SaveChanges();

            var persons = new List<Person>()
            {
                new Person
                {
                    FirstName = "Musa",
                    LastName = "Zulu",
                    Email = "musa@chillisoft.co.za",
                    Address = "some address",
                },
                     new Person
                {
                    FirstName = "Scelumusa",
                    LastName = "Nkosi",
                    Email = "sce@gamil.com",
                    Address = "some address",
                }
            };

            foreach (var person in persons)
            {
                context.Persons.Add(person);
            }
            context.SaveChanges();

            var meetingItemStatus = new List<MeetingItemStatus>()
            {
                new MeetingItemStatus
                {
                    CurrentStatus = "On Progress",
                    ActionRequired = "Fix Bug",
                    PersonId = 1
                },

                   new MeetingItemStatus
                {
                     CurrentStatus = "On Progress",
                    ActionRequired = "Fix Bug",
                    PersonId = 2
                },
            };
            foreach (var meetingItemStatuse in meetingItemStatus)
            {
                context.MeetingItemStatuses.Add(meetingItemStatuse);
            }
            context.SaveChanges();

        }
    }
}