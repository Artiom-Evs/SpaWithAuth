import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class Home extends Component {
    constructor(props) {
      super(props);
      this.state = { user: null };
    }

    componentDidMount() {
      this.loadData();
    }

    async loadData() {
        this.setState({ user: await authService.getUser() });
    }

    render() {
      let { user } = this.state;      
      return (
        <div>
          <h1>Claims</h1>
          {JSON.stringify(user)}
        </div>
      );
    }
}
