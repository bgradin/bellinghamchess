# bellinghamchess.gradinware.com

[![Build Status](https://travis-ci.com/bgradin/bellinghamchess.svg?branch=master)](https://travis-ci.com/bgradin/bellinghamchess)

Bellingham Chess Prototype

## Dependencies

- [Docker](https://www.docker.com/)
- [Yarn](https://yarnpkg.com/)

## Developing

I'm developing on Windows using [WSL](https://docs.microsoft.com/en-us/windows/wsl/about) through [VSCode](https://code.visualstudio.com/). Theoretically this code should compile on anywhere on 64-bit linux.

Run `make` to start a dev server at [localhost:8080](http://localhost:8080). `make help` lists all available options.

## Deployment

All builds trigger Travis CI, but tags will additionally deploy the site code to my VPS.

## Open questions

- Should players be able to self-register, or does an admin need to do it?
- Does the ladder need to be displayed as an image, or can it be displayed as plain text?
