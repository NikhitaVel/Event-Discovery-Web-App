## Logo
![logo](https://github.com/shreyasnadig/fourfivetwo/assets/42885687/da7db9fa-3137-4049-85cb-10918e9444e2)


## Introduction
- fourfivetwo_ is your one stop shop for everything happening in and around Cincy!
- We provide a huge catalogue of events that have occured in the past and those which are coming up.
- Our aim is to encourage and celebrate the diverse talent pool we have in the city and give an opportunity for the people to explore different events happening while promoting artists.

## Story board (WIP)

> Home Page

<img width="355" alt="image" src="https://github.com/shreyasnadig/fourfivetwo/assets/42885687/3127bf39-0a75-41c3-a45c-adc4c6052482">

_____________

> Event details page

<img width="345" alt="image" src="https://github.com/shreyasnadig/fourfivetwo/assets/42885687/d53437bc-6dc8-4f11-a307-21df3f89e39e">

_______________

> Artist details page

<img width="294" alt="image" src="https://github.com/shreyasnadig/fourfivetwo/assets/42885687/292d1e5b-8e90-43a0-8860-a99bdd28baa9">


## Data Feeds

[Ticketmaster Open API](https://developer.ticketmaster.com/products-and-docs/apis/getting-started/)

[Eventbrite Open API](https://www.eventbrite.com/platform/api#/introduction/basic-types)

## Functional Requirements
### Requirement 1: Event and Artists Search:
#### Scenario
As a user, I can search for events based on category (e.g., music, sports, standup), performers, and venue so that I can view upcoming events and buy tickets.

#### Dependencies
Event search data are available and accessible.

#### Assumptions
#### Examples
<br>

##### 1.1 
<br>
<strong>Given</strong> A list of upcoming events in Cincinnati are available<br>
<strong>When</strong> I search for “music”<br>
<strong>Then</strong> I should receive results with these attributes if there is at least one upcoming event and artist: <br>
<br>
Event names: Eras Tour, Cincy Music Festival, and others<br>
Categories of each event<br>
Location of each event<br>
Start Date for each event<br>
End Date for each event<br>
Redirection button to see events<br>
<br>
Artists: Taylor Swift, The Weekend, and others
Short bio of each artist<br>
Redirection button to learn more about artists<br>
<br>

##### 1.2 
<br>
<strong>Given</strong> A list of upcoming events in Cincinnati are available<br>
<strong>When</strong> I search for “Taylor Swift”<br>
<strong>Then</strong> I should receive results with these attributes if there is at least one upcoming event and artist: <br>
<br>
Event names: Eras Tour<br>
Categories: Documentary<br>
Location: Esquire Theatre<br>
Start Date: October 13, 2023<br>
End Date: November 1, 2023<br>
Redirection button to see event details
<br>
<br>
Artists: Taylor Swift<br>
Short bio of Taylor Swift<br>
Redirection button to learn more about artists<br>
<br>

##### 1.3
<br>
<strong>Given</strong> A list of upcoming events in Cincinnati are available<br>
<strong>When</strong> I search for “hoolahooping”<br>
<strong>Then</strong> I should receive zero results (an empty list) with a “no upcoming events” message displayed
<br>
<br>


### Requirement 2: Add events to calendars:
#### Scenario:
As a user, I can add events to my calendar and receive event reminders.

#### Dependencies:
Event search data are available and accessible.

#### Example
<br>

##### 2.1
<br>
<strong>Given</strong> A list of upcoming events in Cincinnati are available<br>
<strong>When</strong> I go to the details page of “Eras Tour” and click on “Add to Calendar” button<br>
<strong>Then</strong> an option to download the calendar file (iCal or Google Calendar) should appear on the screen.
<br>

### Requirement 3: Reviews, Ratings and Comments:
#### Scenario:
As a user, I can access the artist's details page and provide ratings and reviews for them.

#### Dependencies:
Artist search data are available and accessible.

#### Examples
<br>

##### 3.1 
<br>
<strong>Given</strong> A list of upcoming events in Cincinnati are available<br>
<strong>When</strong> I go to the details page of “Taylor Swift”<br>
<strong>Then</strong> I should be able to provide rating for Taylor Swift
<br>

##### 3.2 
<br>
<strong>Given</strong> A list of upcoming events in Cincinnati are available<br>
<strong>When</strong> I go to the details page of “Taylor Swift”<br>
<strong>Then</strong> I should be able to provide review for Taylor Swift
<br>

##### 3.3 
<br>
<strong>Given</strong> A list of upcoming events in Cincinnati are available<br>
<strong>When</strong> I go to the details page of “Taylor Swift”<br>
<strong>Then</strong> I should be able to post comments.
<br>

### Requirement 4: Social Sharing:
#### Scenario:
As a user, I can share event details on social media platforms to invite friends and build a social aspect around attending events.

#### Dependencies:
Event and artist data are available and accessible.

#### Example
<br>

##### 4.1
<br>
<strong>Given</strong> A list of upcoming events in Cincinnati are available<br>
<strong>When</strong> I click on a 'Share' button for “Eras Tour”<br>
<strong>Then</strong> A URL (like <a href=https://g.co/kgs/Ajt3oQ>https://g.co/kgs/Ajt3oQ</a>) should be generated for that event, allowing me to easily share it on my social media platforms.
<br>

## Scrum Roles
- DevOps/Product Owner/Scrum Master: Shreyas Nadig
- Frontend Developer: Archana Basnett
- Integration Developer: Nikhita Veluri

## Weekly Meeting
Friday at 11 AM in person
