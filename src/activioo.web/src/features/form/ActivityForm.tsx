import React from 'react'
import { Segment, Form } from 'semantic-ui-react';

export const ActivityForm = () => {
  return (
    <Segment>
      <Form>
        <Form.Input icon='write' iconPosition='left' placeholder='Title' />
        <Form.TextArea rows={2} placeholder='Description' />
        <Form.Input placeholder='Category' />
        <Form.Input icon='calendar alternate' iconPosition='left' type='date' placeholder='Date' />
        <Form.Input icon='building' iconPosition='left' placeholder='City' />
      </Form>

    </Segment>
  )
}
