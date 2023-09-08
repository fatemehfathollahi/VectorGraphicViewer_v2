Feature: Canvas Integration
    As a user
    I want to be able to create and edit a circle on the canvas

    Scenario: Create and Edit Circle
        Given the canvas is empty
        When I read the circle data from the JSON file
        Then the circle should be rendered on the canvas
