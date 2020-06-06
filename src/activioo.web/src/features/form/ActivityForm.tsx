import React, { useState } from "react";
import { Segment, Form, Button } from "semantic-ui-react";
import { IActivity } from "../../app/models/activity";

interface IProps {
  setEditMode: (editMode: boolean) => void;
  activity: IActivity;
}

export const ActivityForm: React.FC<IProps> = ({
  setEditMode,
  activity: initialFormState,
}) => {
  const initializeForm = () => {
    if (initialFormState) {
      return initialFormState;
    } else {
      return {
        id: "",
        title: "",
        category: "",
        description: "",
        date: "",
        city: "",
        venue: "",
      };
    }
  };

  const [activity, setActivity] = useState<IActivity>(initializeForm);

  return (
    <Segment clearing>
      <Form>
        <Form.Input
          icon="write"
          iconPosition="left"
          placeholder="Title"
          value={activity.title}
        />
        <Form.TextArea
          rows={2}
          placeholder="Description"
          value={activity.description}
        />
        <Form.Input
          icon="terminal"
          iconPosition="left"
          placeholder="Category"
          value={activity.category}
        />
        <Form.Input
          icon="calendar alternate"
          iconPosition="left"
          type="date"
          placeholder="Date"
          value={activity.date}
        />
        <Form.Input
          icon="building"
          iconPosition="left"
          placeholder="City"
          value={activity.city}
        />
        <Form.Input
          icon="hdd"
          iconPosition="left"
          placeholder="Venue"
          value={activity.venue}
        />
        <Button
          icon="add"
          color="green"
          floated="right"
          inverted
          type="submit"
          content="Submit"
        />
        <Button
          onClick={() => setEditMode(false)}
          icon="cancel"
          color="red"
          floated="right"
          inverted
          type="button"
          content="Cancel"
        />
      </Form>
    </Segment>
  );
};
