import React, {Component} from 'react';
import {Container} from 'reactstrap';

export class Blog extends Component {
    static displayName = Blog.name;

    constructor(props) {
        super(props);
        this.state = {blogs: [], loading: true};

        fetch('api/Blog')
            .then(response => response.json())
            .then(data => {
                this.setState({blogs: data, loading: false});
            });
    }

    static renderBlogList(blogs) {
        return (
            <div>
                {blogs.map(blog =>
                    <div key={blog.id} className="card mb-4">
                        <div className="card-body row">
                            <div className="col-sm-8 mb-3">
                                <h2 className="card-title">{blog.title}</h2>
                                <p className="card-text">{blog.body}</p>
                            </div>
                            <div className="col-sm-4">
                                <img className="card-img-top" src={blog.imgPath} alt="" height="100%"
                                     width="100%"/>
                            </div>
                        </div>
                        <div className="card-footer text-muted">
                            {blog.postDate} | {blog.metaData}
                        </div>
                    </div>
                )}
            </div>
        );
    }

    render() {
        return (
            <div className="py-5">
                <div id="blogHeader" className="mb-3">
                    <h1 className="text-center">
                        Блог
                    </h1>
                </div>
                <Container>
                    {Blog.renderBlogList(this.state.blogs)}
                </Container>
            </div>
        );
    }
}