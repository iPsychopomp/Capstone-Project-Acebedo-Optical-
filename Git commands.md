## 🧩 1. Initialize Git

```bash
git init
```
#### Creates a new local Git repository.

&nbsp;

```bash
git add .
```
#### Stages all changes for the next commit.

&nbsp;

```bash
git commit -m "Initial commit"
```
#### Saves a snapshot of your changes locally.

&nbsp;

```bash
git remote add origin https://github.com/username/repo-name.git
```
#### Links your local repository to the remote one.

&nbsp;

```bash
git branch -M main
```
#### Renames the current branch to main, even if a branch named main already exists.

&nbsp;

```bash
git push -u origin main
```
#### Push your commits to GitHub (main branch)


```bash
git push
```
#### The -u flag sets upstream tracking so future pushes only need git push.

&nbsp;

```bash
git pull origin main
```
## Combines fetch and merge — downloads and merges remote changes.

---

#### Create a .gitignore file to exclude unnecessary files (e.g., build outputs).
```markdown
bin/
obj/
*.user
*.suo
*.cache
*.exe
*.dll
```

---

#### Clone an Existing Repository
```bash
git clone https://github.com/username/repo-name.git
```
#### If you’re joining the project or setting up on another PC
