import React, { useState, FormEvent, useContext, useEffect } from "react";
import { Segment, Form, Button } from "semantic-ui-react";
import { IActivity } from "../../app/models/activity";
import { v4 as Guid } from "uuid";
import ActivityStore from "../../app/stores/ActivityStore";
import { observer } from "mobx-react-lite";
import { RouteComponentProps } from 'react-router-dom';


interface DetailParams {
  id:string;
}
const ActivityForm: React.FC<RouteComponentProps<DetailParams>> = ({match}) => {
  const activityStore = useContext(ActivityStore);
  const {
    createActivity,
    editActivity,
    submitting,
    cancelFormOpen,
    activity: initialFormState,
    loadActivity,
    clearActivity
  } = activityStore;

  useEffect(() => {
    if (match.params.id) {
      loadActivity(match.params.id).then(() => initialFormState && setActivity(initialFormState))
    }
    return () => {
      clearActivity()
    }
  }, [loadActivity, match.params.id, clearActivity, initialFormState])

  const [activity, setActivity] = useState<IActivity>({
      id: "",
      title: "",
      category: "",
      description: "",
      date: "",
      city: "",
      venue: "",
  });

  const handleInputChange = (
    event: FormEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = event.currentTarget;
    setActivity({ ...activity, [name]: value });
  };

  const handleSubmit = () => {
    if (activity.id.length === 0) {
      let newActivity = {
        ...activity,
        id: Guid(),
      };
      createActivity(newActivity);
    } else {
      editActivity(activity);
    }
  };

  return (
    <Segment clearing>
      <Form onSubmit={handleSubmit}>
        <Form.Input
          onChange={handleInputChange}
          name="title"
          icon="write"
          iconPosition="left"
          placeholder="Title"
          value={activity.title}
        />
        <Form.TextArea
          onChange={handleInputChange}
          name="description"
          rows={2}
          placeholder="Description"
          value={activity.description}
        />
        <Form.Input
          onChange={handleInputChange}
          name="category"
          icon="terminal"
          iconPosition="left"
          placeholder="Category"
          value={activity.category}
        />
        <Form.Input
          onChange={handleInputChange}
          name="date"
          icon="calendar alternate"
          iconPosition="left"
          type="datetime-local"
          placeholder="Date"
          value={activity.date}
        />
        <Form.Input
          onChange={handleInputChange}
          name="city"
          icon="building"
          iconPosition="left"
          placeholder="City"
          value={activity.city}
        />
        <Form.Input
          onChange={handleInputChange}
          name="venue"
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
          loading={submitting}
        />
        <Button
          onClick={cancelFormOpen}
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

export default observer(ActivityForm);
