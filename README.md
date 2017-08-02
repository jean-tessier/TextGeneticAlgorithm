# Text Genetic Algorithm
A Simple Genetic Algorithm, implemented in C#, exemplifying the abilities of Genetic Algorithms. The goal of this project is to refresh my memory of my original genetic algorithm project, which was implemented in Java, while learning a new programming language and implementing new techniques acquired through my years of education.

## 1. Introduction: Genetic Algorithms
Biological evolution has proven itself to be able to accomplish the seemingly impossible. For the problem of genetic survival, not only are there
innumerable "solutions", but infinitely-many subtle variables impacting the viability of said solutions. 

When a biological "solution", provided by life's genetic code, proved itself to be sub-optimal or subversive, evolution whittled away 
at their continued reproduction, slowly removing "bad solutions" from the gene pool. Conversely, when a biological "solution" proved 
itself in someway beneficial, evolution rewarded it by increasing its reproduction, slowly increasing the availability of these 
"good solutions" to the problem of genetic survival.

By applying the successful principles developed by millions upon millions of years of evolution to real-world problems through software,
we can find efficient solutions to complex problems quickly and effectively.

## 2. Implementation
I chose to implement this algorithm around "optimizing" a string for simplicity's sake. This makes calculating fitness simple: I select a goal string, compare characters from the goal string to the test strings. This also makes for an easy display to share the algorithm's output with those who may not understand how it works.

Rather than choosing breeding pairs from the population as a whole, I select a subset of Individuals from the Population, then select a breeeding pair from this subset. I was interested in any difference this may make from my previous implementation utilizing the former; I now realize it would be simpler to compare if I were to try both strategies from this implementation to find which runtime is faster.

### Classes

#### Individual
- Represents a single member of a population. 
- _**Key Fields**_:
  - Genes: Contains the "genetic" information about the Individual. In this
    case, the genes are represented by a string of characters.
  - Fitness: How effective this Individual is at achieving its goal. In this
    case, fitness is determined by how many characters match the specified goal
    string.
- _**Key Methods**_:
  - **Crossover(Individual i)**: This function is the "breeding" function. This
    merges the genes of two Individuals by randomly selecting a "center" of the
    genes, and giving the child Individual the portions of the genes of the two
    Individuals. Along with **mutate()**, this is the engine of the algorithm.
  - **Mutate()**: This function provides the entropy that allows the algorithm
    to progress. Most mutations will be bad, but these will not be rewarded by
    an increase in fitness as good mutations will; this means good mutations are
    more likely to persist. Along with **crossover()**, this is the engine of
    the algorithm.
    
#### Population
- Represents a group of Indiviudals -- primarily used to represent one generation of Individuals
- _**Key Fields**_:
  - Pop: Contains each of the individuals in the population. Using a dynamically sized data structure allows for simplicity, but implementing this as an array would quite likely improve runtime.
- _**Key Methods**_:
  - **SelectIndividualsAtRandom(int numToSelect)**: This function returns a random subset of Individuals from the Population. This is used primarily when selecting the "tournament pool" -- the subset of the Population that will compete for breeding privileges.
  - **SelectIndividualsAtRandomWeighted(int numToSelect)**: This function returns a weighted-random subset of Individuals from the Population using fitness as the weight. This is primarily used to select the "victors" from the tournament pool.
