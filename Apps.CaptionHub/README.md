﻿# Blackbird.io CaptionHub

Blackbird is the new automation backbone for the language technology industry. Blackbird provides enterprise-scale automation and orchestration with a simple no-code/low-code platform. Blackbird enables ambitious organizations to identify, vet and automate as many processes as possible. Not just localization workflows, but any business and IT process. This repository represents an application that is deployable on Blackbird and usable inside the workflow editor.

## Introduction

<!-- begin docs -->

CaptionHub is a cloud-based platform that provided services related to video captioning and subtitling. This CaptionHub application primarily centers around project and caption set management.

## Connecting

1.  Navigate to apps and search for CaptionHub. If you cannot find CaptionHub then click _Add App_ in the top right corner, select CaptionHub and add the app to your Blackbird environment.
2.  Click _Add Connection_.
3.  Name your connection for future reference e.g. 'My client'.
4.  Go to CaptionHub team settings and choose _API Keys_ from the menu in the left.
5.  Go to the _API Keys_ section and click _Create API Key_
6.  Copy API key and paste it to the appropriate field in the BlackBird
7.  Click _Connect_.
8.  Confirm that the connection has appeared and the status is _Connected_.

## Actions

### Activities

- **List activities** returns a list of all activities for a `Team`, `Project` or `Caption set`.

### Automations

- **List automations** returns a list of all automations that can be applied to a `Project` on creation.

### Caption sets

- **List caption sets** returns a list of caption sets data that a user is editing.
- **Approve caption set** marks all segments in a caption set as approved.
- **Make caption set reviewable** makes all segments in a caption set reviewable.
- **Make caption set claimable** makes all segments in a caption set claimable.
- **Create translated caption set** creates a caption set ready for translation.
- **Create original caption set** creates a new original caption set.
- **Download original/translated captions** downloads a caption set in the requested format.
- **Publish caption set** publishes a caption set.

### Custom dictionaries

- **Get custom dictionary** returns details of a specific custom dictionary.
- **List custom dictionaries** returns a list of all custom dictionaries belonging to your team.

### Languages

- **List languages** returns a list of all available languages for your team.

### Projects

- **Get/create/update/delete project**
- **Replace the video for a project** replaces the original video for a project.

### Renders

- **Get render status** returns the status of a render.
- **Create render** creates a render for the the given `Caption set`.
- **Download render** downloads a completed render.

### Teams

- **List teams** returns a list of all teams the API user is a member of.

### Termbases

- **List termbases** returns a list of all termbases for your `Team`.

### Users

- **List users** returns a list of all users for your `Team`.

### Workflow transitions

- **List workflow transitions** returns a list of all workflow transitions for a team, project or caption set.

## Missing features

In the future we can add actions for:

- Team workflows

## Feedback

Feedback to our implementation of CaptionHub is always very welcome. Reach out to us using the established channels or create an issue.

<!-- end docs -->
